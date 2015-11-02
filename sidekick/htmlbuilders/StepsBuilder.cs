using System;
using System.Web.Mvc;

namespace sidekick
{
    public class StepsBuilder<TModel> : BuilderBase<TModel>, IDisposable
    {
        public StepsBuilder(HtmlHelper<TModel> helper, int totalSteps)
            : base(helper) {
            WriteLine("<div class='col-md-12 progress-area'>");
            WriteLine(String.Format("<ol class='progtrckr' data-progtrckr-steps='{0}'>", totalSteps));
        }

        public MvcHtmlString AddStep(Step step) {
            string complete = (step.Complete) ? "done" : "todo";
            string icon = !String.IsNullOrEmpty(step.Icon) ? String.Format("<i class='{0}'></i> ", step.Icon) : null;
            WriteLine(String.Format("<li class='progtrckr-{0}' data-toggle='tooltip' data-placement='bottom' title='{1}'>{2}{3}</li>", 
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
            WriteLine("</ol></div>");
        }
    }
}
