using System.Collections.Generic;

namespace Translations.Core.Models
{
    public class Product : ITranslatable<Product, ProductTranslation>
    {
        /// <summary>
        ///     Unique identifier
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        ///     1 to Many translations
        /// </summary>
        public virtual ICollection<ProductTranslation> Translations { get; set; }
    }
}