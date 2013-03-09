using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Translations.Core.Extensions;
using Translations.Core.LinqKit.KnownExpressions;
using Translations.Core.LinqKit.Library;
using Translations.Core.Models;

namespace Translations.Core.LinqKit
{
    class ReplacingExpressionsExpander: ExpressionExpander
    {
        private static readonly IExpressionReplacer<MethodCallExpression>[] MethodCallReplacers
            = new IExpressionReplacer<MethodCallExpression>[] {new ExpressionReplacerForExtensionsForITranslatableCurrent()};

        protected override Expression VisitMethodCall(MethodCallExpression methodCallExpression)
        {
            foreach (var replacer in MethodCallReplacers.Where(replacer => replacer.ShouldReplace(methodCallExpression)))
            {
                return Visit(replacer.GetReplacement(methodCallExpression));
            }
            return base.VisitMethodCall(methodCallExpression);
        }
    }
}
