using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Translations.Core.Models;

namespace Translations.Core.Extensions
{
    public static class ExtensionsForITranslatable
    {
        /// <summary>
        ///     Returns the current appropriate translation for this <paramref name="translatable"/>
        /// </summary>
        /// <typeparam name="TTranslatable">The translatable type</typeparam>
        /// <typeparam name="TTranslation">The translation type</typeparam>
        /// <param name="translatable">This instance of a translatable class</param>
        /// <returns>The current appropriate translation for this <paramref name="translatable"/></returns>
        public static TTranslation Current<TTranslatable, TTranslation>(
                this ITranslatable<TTranslatable, TTranslation> translatable)
            where TTranslation : class, ITranslation<TTranslatable>
            where TTranslatable : class, ITranslatable<TTranslatable, TTranslation>
        {
            // Get current default UI culture info
            string currentCultureName = CultureInfo.DefaultThreadCurrentUICulture.Name;
            return translatable.Translations.SingleOrDefault(t => t.CultureName == currentCultureName);
        }
    }
}
