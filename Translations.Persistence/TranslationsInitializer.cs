using System.Collections.ObjectModel;
using System.Data.Entity;
using Translations.Core;
using Translations.Core.Models;

namespace Translations.Persistence
{
    public class TranslationsInitializer: DropCreateDatabaseAlways<TranslationsContext>
    {
        protected override void Seed(TranslationsContext context)
        {
            context.Products.Add(new Product
                {
                    Translations = new Collection<ProductTranslation>
                        {
                            new ProductTranslation {CultureName = "nl-BE", Name = "Melk"},
                            new ProductTranslation {CultureName = "", Name = "Milk"},
                            new ProductTranslation {CultureName = "fr-FR", Name = "Lait"}
                        }
                });
            context.Products.Add(new Product
                {
                    Translations = new Collection<ProductTranslation>
                        {
                            new ProductTranslation {CultureName = "nl-BE", Name = "Eieren"},
                            new ProductTranslation {CultureName = "", Name = "Eggs"},
                            new ProductTranslation {CultureName = "fr-FR", Name = "Oeufs"}
                        }
                });
            context.Products.Add(new Product
                {
                    Translations = new Collection<ProductTranslation>
                        {
                            new ProductTranslation {CultureName = "nl-BE", Name = "Kaas"},
                            new ProductTranslation {CultureName = "", Name = "Cheese"},
                            new ProductTranslation {CultureName = "fr-FR", Name = "Fromage"}
                        }
                });
            context.Products.Add(new Product
                {
                    Translations = new Collection<ProductTranslation>
                        {
                            new ProductTranslation {CultureName = "nl-BE", Name = "Boter"},
                            new ProductTranslation {CultureName = "", Name = "Butter"},
                            new ProductTranslation {CultureName = "fr-FR", Name = "Beurre"}
                        }
                });
        }
    }
}
