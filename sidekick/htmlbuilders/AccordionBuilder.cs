using System;
using System.Web.Mvc;

namespace sidekick
{
    /// <summary>
    ///     HTML builder for a Bootstrap 'Accordion' element.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class AccordionBuilder : IDisposable
    {
        private HtmlHelper _helper;
        private Accordion _accordion;

        public AccordionBuilder(HtmlHelper helper, Accordion accordion)
        {
            _helper = helper;
            _accordion = accordion;
            _helper.WriteLine($"<div class='panel-group' id='{_accordion._parentID}' role='tablist' aria-multiselectable='true'>");
        }

        /// <summary>
        ///     Builds an expandable panel in the accordion. HTML ID must be unique for the panel clicked to be the only panel that expands.
        /// </summary>
        /// <param name="panel"></param>
        /// <returns></returns>
        public AccordionPanel BeginPanel(Panel panel, string title, string icon)
        {
            return new AccordionPanel(_helper, _accordion, panel, title, icon);
        }

        public void Dispose()
        {
            _helper.WriteLine("</div>");
        }
    }

    public class AccordionPanel : IDisposable
    {
        private HtmlHelper _helper;

        public AccordionPanel(HtmlHelper helper, Accordion accordion, Panel panel, string title, string icon)
        {
            _helper = helper;
            _helper.WriteLine($"<div class='panel panel-{panel._color.GetAttribute<HtmlBuilderAttribute>().Class}'>");
            _helper.WriteLine($"<div class='panel-heading' role='tab' id='heading{panel._id}'>");
            _helper.WriteLine("<h4 class='panel-title'>");
            _helper.WriteLine($"<a role='button' data-toggle='collapse' data-parent='#{accordion._parentID}' href='#collapsed{panel._id}' aria-expanded='false' aria-controls='{panel._id}'>");
            if (!String.IsNullOrEmpty(icon))
                _helper.WriteLine(new IconBuilder(new Icon(icon)).ToHtmlString());

            _helper.WriteLine(title);
            _helper.WriteLine("</a></h4></div>");
            _helper.WriteLine($"<div id='collapsed{panel._id}' class='panel-collapse collapse' role='tabpanel' aria-labelledby='heading{panel._id}'>");
            _helper.WriteLine("<div class='panel-body'>");
        }

        public void Dispose()
        {
            _helper.WriteLine("</div></div></div>");
        }
    }
}
