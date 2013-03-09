using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Translations.Core.Extensions;
using Translations.Core.Models;

namespace Translations.Core.LinqKit.KnownExpressions
{
    /// <summary>
    ///     Dynamically replaces a MethodCallExpression for 'ExtensionsForITranslatable.Current()' to
    ///     a valid equivalent expression
    /// </summary>
    public class ExpressionReplacerForExtensionsForITranslatableCurrent: IExpressionReplacer<MethodCallExpression>
    {
        private readonly MethodInfo _methodInfoForCurrent;

        public ExpressionReplacerForExtensionsForITranslatableCurrent()
        {
            _methodInfoForCurrent = typeof (ExtensionsForITranslatable)
                .GetMethods().Single(m => m.Name == "Current"
                                          && m.GetParameters().Count() == 1
                                          && m.GetParameters().Single().ParameterType.GetGenericTypeDefinition() == typeof (ITranslatable<,>));
        }

        public bool ShouldReplace(MethodCallExpression expression)
        {
            return expression.Method.IsGenericMethod && expression.Method.GetGenericMethodDefinition() == _methodInfoForCurrent;
        }

        public Expression GetReplacement(MethodCallExpression expression)
        {
            // 'translatableObject.Current()' is equivalent to 'ExtensionsForITranslatable.Current(translatableObject)'
            var translatableObject = expression.Arguments.First();
            var translatableType = translatableObject.Type;
            // Get ITranslatable<TEntity, TTranslation> interface declaration of translatableObject
            var translatableInterface = translatableType
                .GetInterfaces()
                .Single(i => i.IsGenericType && typeof(ITranslatable<,>) == i.GetGenericTypeDefinition());
            // Get TTranslation from ITranslatable<TEntity, TTranslation>
            var translationType = translatableInterface
                .GetGenericArguments()
                .Single(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ITranslation<>)));
            // Make dynamic call to MakeCurrentExpression
            var makeExpressionMethod = typeof(ExpressionReplacerForExtensionsForITranslatableCurrent).GetMethod("MakeCurrentExpression");
            var genericMakeExpressionMethod = makeExpressionMethod.MakeGenericMethod(new[] { translatableType, translationType });
            var translationLambda = (LambdaExpression) genericMakeExpressionMethod.Invoke(this, new object[] { CultureInfo.DefaultThreadCurrentUICulture.Name });
            return Expression.Invoke(translationLambda, translatableObject);
        }

        /// <summary>
        ///     Returns the expression that should be inserted at the place where .Current() is called
        /// </summary>
        /// <typeparam name="TTranslatable"></typeparam>
        /// <typeparam name="TTranslation"></typeparam>
        /// <param name="cultureName"></param>
        /// <returns></returns>
        public LambdaExpression MakeCurrentExpression<TTranslatable, TTranslation>(string cultureName)
            where TTranslatable : class, ITranslatable<TTranslatable, TTranslation>
            where TTranslation : class, ITranslation<TTranslatable>
        {
            Expression<Func<TTranslatable, TTranslation>> translationOfCultureFunction =
                translatable => translatable.Translations.FirstOrDefault(t => t.CultureName == cultureName);
            return translationOfCultureFunction;
        }
    }
}
