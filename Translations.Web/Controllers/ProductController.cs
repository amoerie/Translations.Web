using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Translations.Core;
using Translations.Core.Extensions;
using Translations.Core.LinqKit;
using Translations.Core.LinqKit.Library;
using Translations.Core.Models;
using Translations.Persistence;
using Translations.Web.Models;
using System.Data.Entity;

namespace Translations.Web.Controllers
{
    public class ProductController : BaseController
    {
        private readonly TranslationsContext _context;

        public ProductController(TranslationsContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var cultureInfo = CultureInfo.DefaultThreadCurrentUICulture;
            var products = _context.Products.Include(p => p.Translations).AsExpandable().Where(p => p.Current().Name.Contains("a"));
            return View(new ProductsIndexViewModel(cultureInfo, products));
        }

        public ActionResult Detail(int id)
        {
            var product = _context.Products.Find(id);
            return View(product);
        }

    }
}
