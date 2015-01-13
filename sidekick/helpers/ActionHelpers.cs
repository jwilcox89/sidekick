using System;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.UI;
using System.IO;

namespace sidekick
{
    public static class ActionHelpers
    {
        private const string REPLACEMENT_TEXT = "_replace_";

        #region HTML

        public static MvcHtmlString ActionLinkWithIcon(this HtmlHelper helper, string action, string controller, object routeValues, string icon, string altText = null, object htmlAttributes = null) {

            HtmlTextWriter writer = new HtmlTextWriter(new StringWriter());

            writer.AddAttribute(HtmlTextWriterAttribute.Class, icon);
            writer.AddAttribute(HtmlTextWriterAttribute.Alt, altText);
            writer.AddAttribute(HtmlTextWriterAttribute.Title, altText);
            writer.RenderBeginTag(HtmlTextWriterTag.I);
            writer.RenderEndTag();

            string result = helper.ActionLink(REPLACEMENT_TEXT, action, controller, routeValues, htmlAttributes).ToString();
            result = result.Replace(REPLACEMENT_TEXT, writer.InnerWriter.ToString());

            return new MvcHtmlString(result);
        }

        public static MvcHtmlString ActionLinkWithIconAndText(this HtmlHelper helper, string action, string controller, object routeValues, string icon, string text, string altText = null, object htmlAttributes = null) {

            HtmlTextWriter writer = new HtmlTextWriter(new StringWriter());

            writer.AddAttribute(HtmlTextWriterAttribute.Class, icon);
            writer.AddAttribute(HtmlTextWriterAttribute.Alt, altText);
            writer.AddAttribute(HtmlTextWriterAttribute.Title, altText);
            writer.RenderBeginTag(HtmlTextWriterTag.I);
            writer.RenderEndTag();

            string result = helper.ActionLink(REPLACEMENT_TEXT, action, controller, routeValues, htmlAttributes).ToString();
            result = result.Replace(REPLACEMENT_TEXT, string.Format("{0} {1}", writer.InnerWriter.ToString(), text));

            return new MvcHtmlString(result);
        }

        #endregion

        #region AJAX

        public static MvcHtmlString ActionLinkWithIcon(this AjaxHelper helper, string action, string controller, object routeValues, string icon, AjaxOptions options, string altText = null, object htmlAttributes = null) {

            var writer = new HtmlTextWriter(new StringWriter());

            writer.AddAttribute(HtmlTextWriterAttribute.Class, icon);
            writer.AddAttribute(HtmlTextWriterAttribute.Alt, altText);
            writer.AddAttribute(HtmlTextWriterAttribute.Title, altText);
            writer.RenderBeginTag(HtmlTextWriterTag.I);
            writer.RenderEndTag();

            string result = helper.ActionLink(REPLACEMENT_TEXT, action, controller, routeValues, options, htmlAttributes).ToString();
            result = result.Replace(REPLACEMENT_TEXT, writer.InnerWriter.ToString());

            return new MvcHtmlString(result);
        }

        public static MvcHtmlString ActionLinkWithIconAndText(this AjaxHelper helper, string action, string controller, object routeValues, string icon, string text, AjaxOptions options, string altText = null, object htmlAttributes = null) {

            var writer = new HtmlTextWriter(new StringWriter());

            writer.AddAttribute(HtmlTextWriterAttribute.Class, icon);
            writer.AddAttribute(HtmlTextWriterAttribute.Alt, altText);
            writer.AddAttribute(HtmlTextWriterAttribute.Title, altText);
            writer.RenderBeginTag(HtmlTextWriterTag.I);
            writer.RenderEndTag();

            string result = helper.ActionLink(REPLACEMENT_TEXT, action, controller, routeValues, options, htmlAttributes).ToString();
            result = result.Replace(REPLACEMENT_TEXT, string.Format("{0} {1}", writer.InnerWriter.ToString(), text));

            return new MvcHtmlString(result);
        }

        #endregion
    }
}
