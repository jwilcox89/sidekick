using System;
using System.Web.Mvc;

namespace sidekick
{
    public class PanelBuilder : IDisposable
    {
        private HtmlHelper _helper;

        public PanelBuilder(HtmlHelper helper, IPanel panel) {
            _helper = helper;

            string icon = (!string.IsNullOrEmpty(panel.Icon)) ? string.Format("<i class='{0}'></i>", panel.Icon) : null;

            _helper.ViewContext.Writer.Write(string.Format("<div class='panel panel-{0} {1}'>", Extentions.GetDisplayName<PanelColor>(panel.Color), panel.Class));
            _helper.ViewContext.Writer.Write("<div class='panel-heading'>");
            _helper.ViewContext.Writer.Write(string.Format("<{0} class='panel-title'>{1} {2}</{0}>", Extentions.GetDisplayName<HeadingSize>(panel.HeadingSize), icon, panel.Title));
            _helper.ViewContext.Writer.Write("</div>");
            _helper.ViewContext.Writer.Write("<div class='panel-body'>");
        }

        public void Dispose() {
            _helper.ViewContext.Writer.Write("</div></div>");
        }
    }
}
