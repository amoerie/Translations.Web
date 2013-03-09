namespace Translations.Core.Models
{
    /// <summary>
    ///     Interface for all classes that provide translations
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface ITranslation<TEntity> where TEntity: class
    {
        string CultureName { get; set; }
    }
}