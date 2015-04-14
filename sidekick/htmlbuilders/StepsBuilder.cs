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
            _helper.ViewContext.Writer.Write(string.Format("<ol class='progtrckr' data-progtrckr-steps='{0}'>", totalSteps));
        }

        public MvcHtmlString AddStep(IStep step) {
            string complete = (step.Complete) ? "done" : "todo";
            string icon = !string.IsNullOrEmpty(step.Icon) ? string.Format("<i class='{0}'></i> ", step.Icon) : null;
            _helper.ViewContext.Writer.Write(string.Format("<li class='progtrckr-{0}' data-toggle='tooltip' data-placement='bottom' title='{1}'>{2}{3}</li>", 
                                                           complete,
                                                           step.Description, 
                                                           icon, 
                                                           step.Title));
            return new MvcHtmlString(string.Empty);
        }

        public void Dispose() {
            _helper.ViewContext.Writer.Write("</ol>");
            _helper.ViewContext.Writer.Write("</div>");
        }
    }
}
