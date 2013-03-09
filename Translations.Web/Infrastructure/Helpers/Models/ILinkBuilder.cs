using System.Web.Mvc;

namespace Translations.Web.Infrastructure.Helpers.Models
{
    public interface ILinkBuilder
    {
        string Action { get; }
        bool IsAllowed { get; }

        /// <summary>
        ///     Returns a link with a simple label
        /// </summary>
        /// <param name="labelText"></param>
        /// <returns></returns>
        MvcHtmlString ToHtml(string labelText);

        /// <summary>
        ///     Returns a link with a label and an icon
        /// </summary>
        /// <param name="labelText"></param>
        /// <param name="iconClass"></param>
        /// <returns></returns>
        MvcHtmlString ToHtml(string labelText, string iconClass);

        /// <summary>
        /// </summary>
        /// <param name="labelText"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        MvcHtmlString ToHtml(string labelText, object htmlAttributes);

        /// <summary>
        /// </summary>
        /// <param name="labelText"></param>
        /// <param name="iconClass"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        MvcHtmlString ToHtml(string labelText, string iconClass, object htmlAttributes);

        /// <summary>
        /// </summary>
        /// <param name="tagBuilder"></param>
        /// <returns></returns>
        ILinkBuilder SurroundedBy(TagBuilder tagBuilder);

        /// <summary>
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        ILinkBuilder SurroundedBy(string tag);

        /// <summary>
        ///     Utility method to quickly create an add button
        /// </summary>
        /// <param name="labelText"></param>
        /// <returns></returns>
        MvcHtmlString ToAddButton(string labelText);

        /// <summary>
        ///     Utility method to quickly create a delete button
        /// </summary>
        /// <param name="labelText"></param>
        /// <returns></returns>
        MvcHtmlString ToDeleteButton(string labelText);

        /// <summary>
        ///     Utility method to quickly create an edit button
        /// </summary>
        /// <param name="labelText"></param>
        /// <returns></returns>
        MvcHtmlString ToEditButton(string labelText);
    }
}