using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Translations.Web.Infrastructure.RouteHandlers
{
    public class MultiCultureMvcRouteHandler: MvcRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(System.Web.Routing.RequestContext requestContext)
        {
            var cultureName = requestContext.RouteData.Values["culture"] as string;
            if (cultureName != null && CultureInfo.GetCultures(CultureTypes.AllCultures).Any(culture => culture.Name == cultureName))
            {
                    var cultureInfo = CultureInfo.GetCultureInfo(cultureName);
                    CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
            }
            else
            {
                CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;
            }
            return base.GetHttpHandler(requestContext);
        }
    }
}