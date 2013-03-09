using System.Globalization;
using System.Web.Mvc;
using System.Web.Routing;
using JetBrains.Annotations;
using Translations.Web.Infrastructure.Helpers.Models;

namespace Translations.Web.Infrastructure.Helpers
{
    /// <summary>
    ///     Automatically hides or shows links based on authentication
    /// </summary>
    public static class LinkHelper
    {
        /// <summary>
        ///     Generates a fully qualified URL to an action method by using the specified action name.
        /// </summary>
        /// <returns>
        ///     The fully qualified URL to an action method.
        /// </returns>
        /// <param name="html">The html helper</param>
        /// <param name="actionName">The name of the action method.</param>
        public static ILinkBuilder Link(this HtmlHelper html, [AspMvcAction] string actionName)
        {
            return Link(html, actionName, null, null);
        }

        /// <summary>
        ///     Generates a fully qualified URL to an action method by using the specified action name and route values.
        /// </summary>
        /// <returns>
        ///     The fully qualified URL to an action method.
        /// </returns>
        /// <param name="html">The html helper</param>
        /// <param name="actionName">The name of the action method.</param>
        /// <param name="routeValues">An object that contains the parameters for a route. The parameters are retrieved through reflection by examining the properties of the object. The object is typically created by using object initializer syntax.</param>
        public static ILinkBuilder Link(this HtmlHelper html, [AspMvcAction] string actionName, object routeValues)
        {
            return Link(html, actionName, null, new RouteValueDictionary(routeValues));
        }

        /// <summary>
        ///     Generates a fully qualified URL to an action method for the specified action name and route values.
        /// </summary>
        /// <returns>
        ///     The fully qualified URL to an action method.
        /// </returns>
        /// <param name="html">The html helper</param>
        /// <param name="actionName">The name of the action method.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        public static ILinkBuilder Link(this HtmlHelper html,
                                        [AspMvcAction] string actionName,
                                        RouteValueDictionary routeValues)
        {
            return Link(html, actionName, null, routeValues);
        }

        /// <summary>
        ///     Generates a fully qualified URL to an action method by using the specified action name and controller name.
        /// </summary>
        /// <returns>
        ///     The fully qualified URL to an action method.
        /// </returns>
        /// <param name="html">The html helper</param>
        /// <param name="actionName">The name of the action method.</param>
        /// <param name="controllerName">The name of the controller.</param>
        public static ILinkBuilder Link(this HtmlHelper html,
                                        [AspMvcAction] string actionName,
                                        [AspMvcController] string controllerName)
        {
            return Link(html, actionName, controllerName, null);
        }

        /// <summary>
        ///     Generates a fully qualified URL to an action method by using the specified action name, controller name, and route values.
        /// </summary>
        /// <returns>
        ///     The fully qualified URL to an action method.
        /// </returns>
        /// <param name="html">The html helper</param>
        /// <param name="actionName">The name of the action method.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <param name="routeValues">An object that contains the parameters for a route. The parameters are retrieved through reflection by examining the properties of the object. The object is typically created by using object initializer syntax.</param>
        public static ILinkBuilder Link(this HtmlHelper html,
                                        [AspMvcAction] string actionName,
                                        [AspMvcController] string controllerName,
                                        object routeValues)
        {
            return Link(html, actionName, controllerName, new RouteValueDictionary(routeValues));
        }

        /// <summary>
        ///     Generates a fully qualified URL to an action method by using the specified action name, controller name, and route values.
        /// </summary>
        /// <returns>
        ///     The fully qualified URL to an action method.
        /// </returns>
        /// <param name="html">The html helper</param>
        /// <param name="actionName">The name of the action method.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        public static ILinkBuilder Link(this HtmlHelper html,
                                        [AspMvcAction] string actionName,
                                        [AspMvcController] string controllerName,
                                        RouteValueDictionary routeValues)
        {
            var url = new UrlHelper(html.ViewContext.RequestContext);
            return GenerateUrl(html,
                               null,
                               actionName,
                               controllerName,
                               routeValues,
                               url.RouteCollection,
                               url.RequestContext,
                               true);
        }

        /// <summary>
        ///     Returns a string that contains a URL.
        /// </summary>
        /// <returns>
        ///     A string that contains a URL.
        /// </returns>
        /// <param name="htmlHelper">The html helper</param>
        /// <param name="routeName">The route name.</param>
        /// <param name="actionName">The action name.</param>
        /// <param name="controllerName">The controller name.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="routeCollection">The route collection.</param>
        /// <param name="requestContext">The request context.</param>
        /// <param name="includeImplicitMvcValues">true to include implicit MVC values; otherwise. false.</param>
        private static ILinkBuilder GenerateUrl(HtmlHelper htmlHelper,
                                                string routeName,
                                                string actionName,
                                                string controllerName,
                                                RouteValueDictionary routeValues,
                                                RouteCollection routeCollection,
                                                RequestContext requestContext,
                                                bool includeImplicitMvcValues)
        {
            if (CultureInfo.DefaultThreadCurrentUICulture != CultureInfo.InvariantCulture)
            {
                if (routeValues == null)
                    routeValues = new RouteValueDictionary();
                routeValues.Add("culture", CultureInfo.DefaultThreadCurrentUICulture);
            }
            var url = UrlHelper.GenerateUrl(routeName,
                                               actionName,
                                               controllerName,
                                               routeValues,
                                               routeCollection,
                                               requestContext,
                                               includeImplicitMvcValues);
            return new LinkBuilder(url, true);
        }
    }
}