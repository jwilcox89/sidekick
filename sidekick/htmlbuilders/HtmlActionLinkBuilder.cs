using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace sidekick
{
    /// <summary>
    ///     HTML builder for an Html action link element.
    /// </summary>
    public class HtmlActionLinkBuilder : ActionLinkBase<HtmlActionLinkBuilder>, IHtmlString
    {
        private HtmlHelper _helper;

        public HtmlActionLinkBuilder(HtmlHelper helper, string controller, string action)
        {
            _helper = helper;
            _controller = controller;
            _action = action;
        }

        public HtmlActionLinkBuilder(HtmlHelper helper, string controller, string action, string text)
        {
            _helper = helper;
            _controller = controller;
            _action = action;
            _text = text;
        }

        public string ToHtmlString()
        {
            return _helper.ActionLink(REPLACEMENT_TEXT, _action, _controller, _routeValues, _htmlAttributes)
                .ToString()
                .Replace(REPLACEMENT_TEXT, $"{new IconBuilder(_icon).ToHtmlString()} {_text}");
        }
    }
}