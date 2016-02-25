using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace sidekick
{
    public class HtmlActionLinkBuilder : ActionLinkBase<HtmlActionLinkBuilder>, IHtmlString
    {
        private HtmlHelper _helper;

        public HtmlActionLinkBuilder(HtmlHelper helper, string controller, string action, string text = null)
        {
            _helper = helper;
            _text = text;
            _controller = controller;
            _action = action;
        }

        public string ToHtmlString()
        {
            string icon = String.Format("<i class='{0}'></i>", _icon);
            string link = _helper.ActionLink(REPLACEMENT_TEXT, _action, _controller, _routeValues, _htmlAttributes).ToString();
            return link.Replace(REPLACEMENT_TEXT, String.Format("{0} {1}", icon, _text));
        }
    }
}
