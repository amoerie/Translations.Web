using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using System.Web.Mvc;
using Translations.Web.Infrastructure.Extensions;

namespace Translations.Web.Infrastructure.Helpers.Models
{
    [DebuggerDisplay("IsAllowed = {IsAllowed}, Action = {Action}")]
    public class LinkBuilder : ILinkBuilder
    {
        private readonly string _action;
        private readonly bool _isAllowed;
        private readonly Stack<TagBuilder> _surroundingTags;

        internal LinkBuilder(string action, bool isAllowed)
        {
            _action = action;
            _isAllowed = isAllowed;
            _surroundingTags = new Stack<TagBuilder>();
        }

        public LinkBuilder(string action)
        {
            _action = action;
            _isAllowed = true;
        }

        /// <summary>
        ///     Returns a link with a simple label
        /// </summary>
        /// <param name="labelText"></param>
        /// <returns></returns>
        public MvcHtmlString ToHtml(string labelText)
        {
            return ToHtml(labelText, null, null);
        }

        /// <summary>
        ///     Returns a link with a label and an icon
        /// </summary>
        /// <param name="labelText"></param>
        /// <param name="iconClass"></param>
        /// <returns></returns>
        public MvcHtmlString ToHtml(string labelText, string iconClass)
        {
            return ToHtml(labelText, iconClass, null);
        }

        /// <summary>
        /// </summary>
        /// <param name="labelText"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public MvcHtmlString ToHtml(string labelText, object htmlAttributes)
        {
            return ToHtml(labelText, null, htmlAttributes);
        }

        /// <summary>
        /// </summary>
        /// <param name="labelText"></param>
        /// <param name="iconClass"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public MvcHtmlString ToHtml(string labelText, string iconClass, object htmlAttributes)
        {
            if (!_isAllowed)
                return MvcHtmlString.Create("");

            var a = new TagBuilder("a");
            if (!string.IsNullOrWhiteSpace(iconClass))
            {
                var icon = new TagBuilder("i").Class(iconClass);
                a.AppendHtml(icon);
            }
            a.AppendHtml(String.IsNullOrWhiteSpace(labelText) ? string.Empty : HttpUtility.HtmlEncode(labelText));
            a.Attribute("title", labelText);

            if (htmlAttributes != null)
            {
                a.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            }

            a.Attribute("href", _action, true);

            TagBuilder result = a;
            while (_surroundingTags.Count != 0)
            {
                TagBuilder tagBuilder = _surroundingTags.Pop().Html(result);
                result = tagBuilder;
            }

            return result.ToHtml();
        }

        public ILinkBuilder SurroundedBy(TagBuilder tagBuilder)
        {
            _surroundingTags.Push(tagBuilder);
            return this;
        }

        public ILinkBuilder SurroundedBy(string tag)
        {
            return SurroundedBy(new TagBuilder(tag));
        }

        public MvcHtmlString ToAddButton(string labelText)
        {
            return ToHtml(labelText, "icon-white icon-plus", new { @class = "btn btn-success" });
        }

        public MvcHtmlString ToDeleteButton(string labelText)
        {
            return ToHtml(labelText, "icon-white icon-remove", new { @class = "btn btn-danger" });
        }

        public MvcHtmlString ToEditButton(string labelText)
        {
            return ToHtml(labelText, "icon-white icon-edit", new { @class = "btn btn-primary" });
        }

        public string Action
        {
            get { return _action; }
        }

        public bool IsAllowed
        {
            get { return _isAllowed; }
        }

        protected bool Equals(LinkBuilder other)
        {
            return string.Equals(_action, other._action) && _isAllowed.Equals(other._isAllowed);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((LinkBuilder)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_action != null ? _action.GetHashCode() : 0) * 397) ^ _isAllowed.GetHashCode();
            }
        }
    }
}