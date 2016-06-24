using System;
using System.Web;
using System.Web.Mvc;

namespace sidekick
{
    public class ProgressBarBuilder : IHtmlString
    {
        private HtmlHelper _helper;
        private ProgressBar _bar;

        public ProgressBarBuilder(HtmlHelper helper, ProgressBar bar)
        {
            _helper = helper;
            _bar = bar;
        }

        public string ToHtmlString()
        {
            _helper.WriteLine(String.Format("<div class='progress'><div class='progress-bar {0} {1} {2}' role='progressbar' style='width: {3}%;'>", _bar._contextualClass, _bar._stripedClass, _bar._animatedClass, _bar._currentValue));

            if (!String.IsNullOrEmpty(_bar._label))
                _helper.WriteLine(String.Format("<span>{0}</span>", _bar._label));

            _helper.WriteLine("</div></div>");
            return new MvcHtmlString(String.Empty).ToString();
        }
    }
}
