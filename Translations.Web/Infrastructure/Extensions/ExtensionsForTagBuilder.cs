﻿using System.Web;
using System.Web.Mvc;

namespace Translations.Web.Infrastructure.Extensions
{
    /// <summary>
    /// Helper methods that allow builder-style construction of tags
    /// </summary>
    public static class ExtensionsForTagBuilder
    {
        #region Attribute

        /// <summary>
        /// Sets an attribute on this tag
        /// </summary>
        /// <param name="this">This tagbuilder</param>
        /// <param name="attribute">The attribute to set</param>
        /// <param name="value">The value to set</param>
        /// <param name="replaceExisting">A value indicating whether the value should override the existing value should there be one.</param>
        /// <returns>This tagbuilder</returns>
        public static TagBuilder Attribute(this TagBuilder @this, string attribute, string value, bool replaceExisting = false)
        {
            @this.MergeAttribute(attribute, value, replaceExisting);
            return @this;
        }

        /// <summary>
        /// Sets an attribute on this tag
        /// </summary>
        /// <param name="this">This tagbuilder</param>
        /// <param name="attribute"></param>
        /// <param name="html"></param>
        /// <param name="replaceExisting">A value indicating whether the value should override the existing value should there be one.</param>
        /// <returns>This tagbuilder</returns>
        public static TagBuilder Attribute(this TagBuilder @this, string attribute, IHtmlString html, bool replaceExisting = false)
        {
            return Attribute(@this, attribute, html.ToString(), replaceExisting);
        }

        #endregion

        #region Class

        /// <summary>
        /// Adds a class to this tag.
        /// </summary>
        /// <param name="this">This tagbuilder</param>
        /// <param name="class">The class(es) to add</param>
        /// <returns>This tagbuilder</returns>
        public static TagBuilder Class(this TagBuilder @this, string @class)
        {
            @this.AddCssClass(@class);
            return @this;
        }

        #endregion

        #region Html

        /// <summary>
        /// Sets the InnerHtml property of this tag
        /// </summary>
        /// <param name="this">This tagbuilder</param>
        /// <param name="html">The html to set as the html for this tagbuilder</param>
        /// <returns>This tagbuilder</returns>
        public static TagBuilder Html(this TagBuilder @this, string html)
        {
            @this.InnerHtml = html;
            return @this;
        }

        /// <summary>
        /// Sets the InnerHtml property of this tag
        /// </summary>
        /// <param name="this">This tagbuilder</param>
        /// <param name="tag">The tag to set as the html for this tagbuilder</param>
        /// <returns>This tagbuilder</returns>
        public static TagBuilder Html(this TagBuilder @this, TagBuilder tag)
        {
            return Html(@this, tag.ToString());
        }

        /// <summary>
        /// Sets the InnerHtml property of this tag
        /// </summary>
        /// <param name="this">This tagbuilder</param>
        /// <param name="html">The html to set as the html for this tagbuilder</param>
        /// <returns>This tagbuilder</returns>
        public static TagBuilder Html(this TagBuilder @this, IHtmlString html)
        {
            return Html(@this, html.ToString());
        }

        #endregion

        #region AppendHtml

        /// <summary>
        /// Appends to the InnerHtml property of this tag
        /// </summary>
        /// <param name="this">This tagbuilder</param>
        /// <param name="html"></param>
        /// <returns>This tagbuilder</returns>
        public static TagBuilder AppendHtml(this TagBuilder @this, string html)
        {
            if (@this.InnerHtml == null)
                @this.InnerHtml = string.Empty;
            @this.InnerHtml += html;
            return @this;
        }

        /// <summary>
        /// Appends to the InnerHtml property of this tag
        /// </summary>
        /// <param name="this">This tagbuilder</param>
        /// <param name="tag">The tag to append to the html for this tagbuilder</param>
        /// <returns>This tagbuilder</returns>
        public static TagBuilder AppendHtml(this TagBuilder @this, TagBuilder tag)
        {
            return AppendHtml(@this, tag.ToString());
        }

        /// <summary>
        /// Appends to the InnerHtml property of this tag
        /// </summary>
        /// <param name="this">This tagbuilder</param>
        /// <param name="html">The html to append to the html for this tagbuilder</param>
        /// <returns>This tagbuilder</returns>
        public static TagBuilder AppendHtml(this TagBuilder @this, IHtmlString html)
        {
            return AppendHtml(@this, html.ToString());
        }

        #endregion

        #region PrependHtml

        /// <summary>
        /// Prepends to the InnerHtml property of this tag
        /// </summary>
        /// <param name="this">This tagbuilder</param>
        /// <param name="html">The html to prepend to the html for this tagbuilder</param>
        /// <returns>This tagbuilder</returns>
        public static TagBuilder PrependHtml(this TagBuilder @this, string html)
        {
            if (@this.InnerHtml == null)
                @this.InnerHtml = string.Empty;
            @this.InnerHtml = html + @this.InnerHtml;
            return @this;
        }

        /// <summary>
        /// Prepends to the InnerHtml property of this tag
        /// </summary>
        /// <param name="this">This tagbuilder</param>
        /// <param name="tag">The tag to prepend to the html for this tagbuilder</param>
        /// <returns>This tagbuilder</returns>
        public static TagBuilder PrependHtml(this TagBuilder @this, TagBuilder tag)
        {
            return PrependHtml(@this, tag.ToString());
        }

        /// <summary>
        /// Prepends to the InnerHtml property of this tag
        /// </summary>
        /// <param name="this">This tagbuilder</param>
        /// <param name="html">The html to prepend to the html for this tagbuilder</param>
        /// <returns>This tagbuilder</returns>
        public static TagBuilder PrependHtml(this TagBuilder @this, IHtmlString html)
        {
            return PrependHtml(@this, html.ToString());
        }

        #endregion

        /// <summary>
        /// Renders and returns the element as a <see cref="F:System.Web.Mvc.TagRenderMode.Normal"/> element.
        /// </summary>
        /// <param name="this">This tag</param>
        /// <returns>The rendered element as a <see cref="F:System.Web.Mvc.TagRenderMode.Normal"/> element</returns>
        public static MvcHtmlString ToHtml(this TagBuilder @this)
        {
            return MvcHtmlString.Create(@this.ToString());
        }

        /// <summary>
        /// Renders and returns the HTML tag by using the specified render mode.
        /// </summary>
        /// <param name="this">This tag</param>
        /// <param name="renderMode">The render mode.</param>
        /// <returns>The rendered HTML tag by using the specified render mode</returns>
        public static MvcHtmlString ToHtml(this TagBuilder @this, TagRenderMode renderMode)
        {
            return MvcHtmlString.Create(@this.ToString(renderMode));
        }
    }
}