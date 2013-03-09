using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Translations.Core;
using Translations.Core.Models;

namespace Translations.Web.Models
{
    public class ProductsIndexViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public ProductsIndexViewModel(CultureInfo cultureInfo, IEnumerable<Product> products)
        {
            CultureInfo = cultureInfo;
            Products = products;
        }

        public CultureInfo CultureInfo { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}