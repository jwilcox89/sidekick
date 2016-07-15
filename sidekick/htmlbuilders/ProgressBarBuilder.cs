using System;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;

namespace sidekick
{
    public class ProgressBarBuilder : IHtmlString
    {
        private HtmlHelper _helper;
        private IList<ProgressBar> _bar;

        public ProgressBarBuilder(HtmlHelper helper, ProgressBar bar)
        {
            _helper = helper;
            _bar = new List<ProgressBar>();
            _bar.Add(bar);
        }

        /// <summary>
        ///     Add a progress bar section to the stack
        /// </summary>
        /// <param name="bar"></param>
        /// <returns></returns>
        public ProgressBarBuilder AddStack(ProgressBar bar)
        {
            _bar.Add(bar);
            return this;
        }

        public string ToHtmlString()
        {
            _helper.WriteLine("<div class='progress'>");

            foreach (ProgressBar bar in _bar)
            {
                _helper.WriteLine(String.Format("<div class='progress-bar {0} {1} {2}' role='progressbar' style='width: {3}%;'>", bar._contextualClass, bar._stripedClass, bar._animatedClass, bar._currentValue));

                if (!String.IsNullOrEmpty(bar._label))
                    _helper.WriteLine(String.Format("<span>{0}</span>", bar._label));

                _helper.WriteLine("</div>");
            }

            _helper.WriteLine("</div>");
            return new MvcHtmlString(String.Empty).ToString();
        }
    }
}