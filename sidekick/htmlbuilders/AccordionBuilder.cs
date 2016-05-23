using System;
using System.Web.Mvc;

namespace sidekick
{
    /// <summary>
    ///     HTML builder for a Bootstrap 'Accordion' element.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class AccordionBuilder<TModel> : IDisposable
    {
        private HtmlHelper<TModel> _helper;
        private Accordion _accordion;

        public AccordionBuilder(HtmlHelper<TModel> helper, Accordion accordion)
        {
            _helper = helper;
            _accordion = accordion;
            _helper.WriteLine(String.Format("<div class='panel-group' id='{0}' role='tablist' aria-multiselectable='true'>", _accordion._parentID));
        }

        /// <summary>
        ///     Builds an expandable panel in the accordion. HTML ID must be unique for the panel clicked to be the only panel that expands.
        /// </summary>
        /// <param name="panel"></param>
        /// <returns></returns>
        public AccordionPanel<TModel> BeginPanel(Panel panel)
        {
            return new AccordionPanel<TModel>(_helper, _accordion, panel);
        }

        public void Dispose()
        {
            _helper.WriteLine("</div>");
        }
    }

    public class AccordionPanel<TModel> : IDisposable
    {
        private HtmlHelper<TModel> _helper;

        public AccordionPanel(HtmlHelper<TModel> helper, Accordion accordion, Panel panel)
        {
            _helper = helper;
            _helper.WriteLine(String.Format("<div class='panel panel-{0}'>", panel._color.GetAttribute<HtmlBuilderAttribute>().Class));
            _helper.WriteLine(String.Format("<div class='panel-heading' role='tab' id='heading{0}'>", panel._id));
            _helper.WriteLine("<h4 class='panel-title'>");
            _helper.WriteLine(String.Format("<a role='button' data-toggle='collapse' data-parent='#{0}' href='#collapsed{1}' aria-expanded='false' aria-controls='{1}'>", accordion._parentID, panel._id));
            _helper.WriteLine(panel._title);
            _helper.WriteLine("</a></h4></div>");
            _helper.WriteLine(String.Format("<div id='collapsed{0}' class='panel-collapse collapse' role='tabpanel' aria-labelledby='heading{0}'>", panel._id));
            _helper.WriteLine("<div class='panel-body'>");
        }

        public void Dispose()
        {
            _helper.WriteLine("</div></div></div>");
        }
    }
}
