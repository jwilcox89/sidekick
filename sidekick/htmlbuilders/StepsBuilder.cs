﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace sidekick
{
    public class StepsBuilder<TModel> : IDisposable
    {
        private List<Step> _steps;
        private HtmlHelper<TModel> _helper;

        public StepsBuilder(HtmlHelper<TModel> helper)
        {
            _helper = helper;
            _steps = new List<Step>();
        }

        public MvcHtmlString AddStep(string title, Icon icon, string description)
        {
            _steps.Add(new Step(title, icon, description));
            return new MvcHtmlString(String.Empty);
        }

        public MvcHtmlString AddStep(string title, Icon icon, string description, bool complete)
        {
            _steps.Add(new Step(title, icon, description, complete));
            return new MvcHtmlString(String.Empty);
        }

        private void WriteStep(Step step)
        {
            string complete = (step.Complete) ? "done" : "todo";
            _helper.WriteLine(String.Format("<li class='progtrckr-{0}' data-toggle='tooltip' data-placement='bottom' title='{1}'>{2} {3}</li>",
                                     complete,
                                     step.Description,
                                     new IconBuilder(step.Icon).ToHtmlString(),
                                     step.Title));
        }

        public void Dispose()
        {
            _helper.WriteLine("<div class='col-md-12 progress-area'>");
            _helper.WriteLine(String.Format("<ol class='progtrckr' data-progtrckr-steps='{0}'>", _steps.Count));

            _steps.ForEach(x => WriteStep(x));

            _helper.WriteLine("</ol></div>");
        }
    }
}
