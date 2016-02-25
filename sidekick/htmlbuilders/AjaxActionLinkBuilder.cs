using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace sidekick
{
    public class AjaxActionLinkBuilder : ActionLinkBase<AjaxActionLinkBuilder>, IHtmlString
    {
        private AjaxHelper _helper;
        private AjaxOptions _options;

        public AjaxActionLinkBuilder(AjaxHelper helper, string controller, string action, string text = null)
        {
            _helper = helper;
            _text = text;
            _controller = controller;
            _action = action;
        }

        public AjaxActionLinkBuilder AjaxOptions(AjaxOptions options)
        {
            _options = options;
            return this;
        }

        public string ToHtmlString()
        {
            string icon = String.Format("<i class='{0}'></i>", _icon);
            string link = _helper.ActionLink(REPLACEMENT_TEXT, _action, _controller, _routeValues, _options, _htmlAttributes).ToString();
            return link.Replace(REPLACEMENT_TEXT, String.Format("{0} {1}", icon, _text));
        }
    }
}
