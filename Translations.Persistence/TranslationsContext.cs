using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Translations.Core;
using Translations.Core.Models;

namespace Translations.Persistence
{
    public class TranslationsContext: DbContext
    {
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Constructs a new context instance using conventions to create the name of the database to
        ///                 which a connection will be made.  The by-convention name is the full name (namespace + class name)
        ///                 of the derived context class.
        ///                 See the class remarks for how this is used to create a connection.
        /// </summary>
        public TranslationsContext(): this("TranslationsContext")
        {
        }

        /// <summary>
        /// Constructs a new context instance using the given string as the name or connection string for the
        ///                 database to which a connection will be made.
        ///                 See the class remarks for how this is used to create a connection.
        /// </summary>
        /// <param name="nameOrConnectionString">Either the database name or a connection string.</param>
        private TranslationsContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<ProductTranslation>().Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Product>().HasMany(p => p.Translations).WithRequired(pt => pt.Product).HasForeignKey(pt => pt.ProductId);
            modelBuilder.Entity<Product>().Map(m => m.MapInheritedProperties());
            modelBuilder.Entity<ProductTranslation>().Map(m => m.MapInheritedProperties());
        }
    }
}
