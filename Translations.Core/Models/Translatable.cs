using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Translations.Core.Models
{
    /// <summary>
    ///     Interface for all classes that have translatable properties
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TTranslation"></typeparam>
    public interface ITranslatable<TEntity, TTranslation>
        where TTranslation : class, ITranslation<TEntity> 
        where TEntity : class
    {
        ICollection<TTranslation> Translations { get; set; }
    }
}