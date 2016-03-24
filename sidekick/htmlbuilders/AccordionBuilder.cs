using System;
using System.Web.Mvc;

namespace sidekick
{
    public class AccordionBuilder<TModel> : IDisposable
    {
        private HtmlHelper<TModel> _helper;
        private string _parentID;

        /// <summary>
        ///     Use this overload if you want to only be able to open one panel in the accordion at a time
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="parentID"></param>
        public AccordionBuilder(HtmlHelper<TModel> helper, string parentID)
        {
            _helper = helper;
            _parentID = parentID;
            _helper.WriteLine(String.Format("<div class='panel-group' id='{0}' role='tablist' aria-multiselectable='true'>", _parentID));
        }

        /// <summary>
        ///     Use this overload if you want to be able to open more than one panel in the accordion at a time
        /// </summary>
        /// <param name="helper"></param>
        public AccordionBuilder(HtmlHelper<TModel> helper)
        {
            _helper = helper;
            _parentID = String.Empty;
            _helper.WriteLine(String.Format("<div class='panel-group' id='{0}' role='tablist' aria-multiselectable='true'>", _parentID));
        }

        public AccordionPanel<TModel> BeginPanel(string title, string id)
        {
            return new AccordionPanel<TModel>(_helper, title, id, _parentID);
        }

        public void Dispose()
        {
            _helper.WriteLine("</div>");
        }
    }

    public class AccordionPanel<TModel> : IDisposable
    {
        private HtmlHelper<TModel> _helper;

        public AccordionPanel(HtmlHelper<TModel> helper, string title, string id, string parentID)
        {
            _helper = helper;
            _helper.WriteLine("<div class='panel panel-default'>");
            _helper.WriteLine(String.Format("<div class='panel-heading' role='tab' id='heading{0}'>", id));
            _helper.WriteLine("<h4 class='panel-title'>");
            _helper.WriteLine(String.Format("<a role='button' data-toggle='collapse' data-parent='#{0}' href='#collapsed{1}' aria-expanded='false' aria-controls='{1}'>", parentID, id));
            _helper.WriteLine(title);
            _helper.WriteLine("</a></h4></div>");
            _helper.WriteLine(String.Format("<div id='collapsed{0}' class='panel-collapse collapse' role='tabpanel' aria-labelledby='heading{0}'>", id));
            _helper.WriteLine("<div class='panel-body'>");
        }

        public void Dispose()
        {
            _helper.WriteLine("</div></div></div>");
        }
    }
}
