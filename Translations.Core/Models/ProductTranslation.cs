namespace Translations.Core.Models
{
    public class ProductTranslation: ITranslation<Product>
    {
        /// <summary>
        ///     Unique identifier
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        ///     Implemented from <see cref="ITranslation{TEntity}"/>
        /// </summary>
        public string CultureName { get; set; }

        /// <summary>
        ///     Foreign key to Product. Entity Framework will pick up on
        ///     this automatically
        /// </summary>
        public virtual int ProductId { get; set; }

        /// <summary>
        ///     Navigation property to Product.
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        ///     Culture-specific name
        /// </summary>
        public virtual string Name { get; set; }
    }
}
