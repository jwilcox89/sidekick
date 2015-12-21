using System;
using System.Web.Mvc;

namespace sidekick
{
    public class PanelBuilder<TModel> : BuilderBase<TModel>, IDisposable
    {
        public PanelBuilder(HtmlHelper<TModel> helper, Panel panel) : base(helper) 
        {
            WriteLine(String.Format("<div class='panel panel-{0} {1}'>", panel.Color.GetHtmlAttributes<Colors>().Class, panel.Class));
            WriteLine("<div class='panel-heading'>");
            WriteLine(String.Format("<{0} class='panel-title'>{1} {2}</{0}>", panel.HeadingSize.GetHtmlAttributes<HeadingSize>().Tag, (!String.IsNullOrEmpty(panel.Icon)) ? String.Format("<i class='{0}'></i>", panel.Icon) : null, panel.Title));
            WriteLine("</div>");
            WriteLine("<div class='panel-body'>");
        }

        public void Dispose() 
        {
            WriteLine("</div></div>");
        }
    }
}
