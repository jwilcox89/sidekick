using System;
using System.Web.Mvc;

namespace sidekick
{
    public class PanelBuilder<TModel> : IDisposable
    {
        private HtmlHelper<TModel> _helper;

        public PanelBuilder(HtmlHelper<TModel> helper, Panel panel)
        {
            _helper = helper;
            _helper.WriteLine(String.Format("<div class='panel panel-{0} {1}'>", panel._color.GetAttribute<Colors, HtmlBuilderAttribute>().Class, panel._class));
            _helper.WriteLine("<div class='panel-heading'>");
            _helper.WriteLine(String.Format("<{0} class='panel-title'>{1} {2}</{0}>", panel._headingSize.GetAttribute<HeadingSize, HtmlBuilderAttribute>().Tag, (!String.IsNullOrEmpty(panel._icon)) ? String.Format("<i class='{0}'></i>", panel._icon) : null, panel._title));
            _helper.WriteLine("</div>");
            _helper.WriteLine("<div class='panel-body'>");
        }

        public void Dispose()
        {
            _helper.WriteLine("</div></div>");
        }
    }
}
