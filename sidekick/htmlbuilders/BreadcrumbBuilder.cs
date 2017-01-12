using System;
using System.Web.Mvc;

namespace sidekick
{
    /// <summary>
    ///     HTML builder for a Bootstrap 'Breadcrumb' element.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class BreadcrumbBuilder<TModel> : IDisposable
    {
        private HtmlHelper<TModel> _helper;

        public BreadcrumbBuilder(HtmlHelper<TModel> helper)
        {
            _helper = helper;
            _helper.WriteLine("<ol class='breadcrumb'>");
        }

        public BreadcrumbBuilder(HtmlHelper<TModel> helper, string @class)
        {
            _helper = helper;
            _helper.WriteLine($"<ol class='breadcrumb {@class}'>");
        }

        public MvcHtmlString AddCrumb(string url, string title)
        {
            return WriteCrumb(url, title, false);
        }

        public MvcHtmlString AddCrumb(string url, string title, bool active)
        {
            return WriteCrumb(url, title, active);
        }

        private MvcHtmlString WriteCrumb(string url, string title, bool active)
        {
            if (active)
            {
                _helper.WriteLine($"<li class='active'>{title}</li>");
            }
            else
            {
                _helper.WriteLine($"<li><a href='{url}' >{title}</a></li>");
            }

            return new MvcHtmlString(String.Empty);
        }

        public void Dispose()
        {
            _helper.WriteLine("</ol>");
        }
    }
}
