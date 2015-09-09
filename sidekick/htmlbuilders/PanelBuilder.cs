using System;
using System.Web.Mvc;

namespace sidekick
{
    public class PanelBuilder : IDisposable
    {
        private HtmlHelper _helper;

        public PanelBuilder(HtmlHelper helper, Panel panel) {
            _helper = helper;
            _helper.ViewContext.Writer.Write(String.Format("<div class='panel panel-{0} {1}'>", panel.Color.GetHtmlAttributes<Colors>().Class, panel.Class));
            _helper.ViewContext.Writer.Write("<div class='panel-heading'>");
            _helper.ViewContext.Writer.Write(String.Format("<{0} class='panel-title'>{1} {2}</{0}>", panel.HeadingSize.GetHtmlAttributes<HeadingSize>().Tag, (!String.IsNullOrEmpty(panel.Icon)) ? String.Format("<i class='{0}'></i>", panel.Icon) : null, panel.Title));
            _helper.ViewContext.Writer.Write("</div>");
            _helper.ViewContext.Writer.Write("<div class='panel-body'>");
        }

        public void Dispose() {
            _helper.ViewContext.Writer.Write("</div></div>");
        }
    }
}
