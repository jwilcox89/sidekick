using System;
using System.Web.Mvc;

namespace sidekick
{
    public class BreadcrumbBuilder<TModel> : BuilderBase<TModel>, IDisposable
    {
        public BreadcrumbBuilder(HtmlHelper<TModel> helper)
            : base(helper)
        {
            WriteLine("<ol class='breadcrumb'>");
        }

        public MvcHtmlString AddCrumb(string url, string title, bool active = false)
        {
            if (active)
            {
                WriteLine(String.Format("<li class='active'>{0}</li>", title));
            }
            else
            {
                WriteLine(String.Format("<li><a href='{0}'>{1}</a></li>", url, title));
            }

            return new MvcHtmlString(String.Empty);
        }

        public void Dispose()
        {
            WriteLine("</ol>");
        }
    }
}
