using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Translations.Web.Infrastructure.RouteHandlers;

namespace Translations.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            var multiCultureRoute = routes.MapRoute(
                                        name: "Default multiculture",
                                        url: "{culture}/{controller}/{action}/{id}",
                                        defaults:
                                            new
                                            {
                                                culture = UrlParameter.Optional,
                                                controller = "Product",
                                                action = "Index",
                                                id = UrlParameter.Optional
                                            },
                                        constraints: new { culture = @"^[a-z]{1,8}(-[a-zA-Z0-9]{1,8})*$" });
            multiCultureRoute.DataTokens.Add("culture", CultureInfo.DefaultThreadCurrentUICulture);
            multiCultureRoute.RouteHandler = new MultiCultureMvcRouteHandler();

            var singleCultureRoute = routes.MapRoute(
                            name: "Default singleculture",
                            url: "{controller}/{action}/{id}",
                            defaults:
                                new
                                {
                                    controller = "Product",
                                    action = "Index",
                                    id = UrlParameter.Optional
                                });
            singleCultureRoute.DataTokens.Add("culture", CultureInfo.InvariantCulture);
            singleCultureRoute.RouteHandler = new MultiCultureMvcRouteHandler();

            

            
        }
    }
}