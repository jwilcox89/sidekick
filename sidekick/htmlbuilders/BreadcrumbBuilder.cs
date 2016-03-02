using System;
using System.Web.Mvc;

namespace sidekick
{
    public class BreadcrumbBuilder<TModel> : IDisposable
    {
        private HtmlHelper<TModel> _helper;

        public BreadcrumbBuilder(HtmlHelper<TModel> helper)
        {
            _helper = helper;
            _helper.WriteLine("<ol class='breadcrumb'>");
        }

        public MvcHtmlString AddCrumb(string url, string title, bool active = false)
        {
            if (active)
            {
                _helper.WriteLine(String.Format("<li class='active'>{0}</li>", title));
            }
            else
            {
                _helper.WriteLine(String.Format("<li><a href='{0}'>{1}</a></li>", url, title));
            }

            return new MvcHtmlString(String.Empty);
        }

        public void Dispose()
        {
            _helper.WriteLine("</ol>");
        }
    }
}
