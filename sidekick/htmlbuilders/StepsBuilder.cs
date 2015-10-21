using System;
using System.Web.Mvc;

namespace sidekick
{
    public class StepsBuilder : IDisposable
    {
        private HtmlHelper _helper;

        public StepsBuilder(HtmlHelper helper, int totalSteps) {
            _helper = helper;
            _helper.ViewContext.Writer.Write("<div class='col-md-12 progress-area'>");
            _helper.ViewContext.Writer.Write(String.Format("<ol class='progtrckr' data-progtrckr-steps='{0}'>", totalSteps));
        }

        public MvcHtmlString AddStep(Step step) {
            string complete = (step.Complete) ? "done" : "todo";
            string icon = !String.IsNullOrEmpty(step.Icon) ? String.Format("<i class='{0}'></i> ", step.Icon) : null;
            _helper.ViewContext.Writer.Write(String.Format("<li class='progtrckr-{0}' data-toggle='tooltip' data-placement='bottom' title='{1}'>{2}{3}</li>", 
                                                           complete,
                                                           step.Description, 
                                                           icon, 
                                                           step.Title));
            return new MvcHtmlString(String.Empty);
        }

        public MvcHtmlString AddStep(string title, string icon, string description, bool complete = false) {
            return AddStep(new Step(title, icon, description, complete));
        }

        public void Dispose() {
            _helper.ViewContext.Writer.Write("</ol></div>");
        }
    }
}
