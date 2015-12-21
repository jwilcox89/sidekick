using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace sidekick
{
    public class StepsBuilder<TModel> : BuilderBase<TModel>, IDisposable
    {
        private List<Step> _steps;

        public StepsBuilder(HtmlHelper<TModel> helper) : base(helper) 
        {
            _steps = new List<Step>();
        }

        public MvcHtmlString AddStep(Step step) 
        {
            _steps.Add(step);
            return new MvcHtmlString(String.Empty);
        }

        public MvcHtmlString AddStep(string title, string icon, string description, bool complete = false) 
        {
            _steps.Add(new Step(title, icon, description, complete));
            return new MvcHtmlString(String.Empty);
        }

        private void WriteStep(Step step) 
        {
            string complete = (step.Complete) ? "done" : "todo";
            string icon = !String.IsNullOrEmpty(step.Icon) ? String.Format("<i class='{0}'></i> ", step.Icon) : null;
            WriteLine(String.Format("<li class='progtrckr-{0}' data-toggle='tooltip' data-placement='bottom' title='{1}'>{2}{3}</li>", 
                                     complete,
                                     step.Description, 
                                     icon, 
                                     step.Title));
        }

        public void Dispose() 
        {
            WriteLine("<div class='col-md-12 progress-area'>");
            WriteLine(String.Format("<ol class='progtrckr' data-progtrckr-steps='{0}'>", _steps.Count));

            _steps.ForEach(x => WriteStep(x));

            WriteLine("</ol></div>");
        }
    }
}
