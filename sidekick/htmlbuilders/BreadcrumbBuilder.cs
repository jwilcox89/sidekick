using System;
using System.Web.Mvc;

namespace sidekick
{
    public class BreadcrumbBuilder : IDisposable
    {
        private HtmlHelper _helper;

        public BreadcrumbBuilder(HtmlHelper helper) {
            _helper = helper;

            _helper.ViewContext.Writer.Write("<ol class='breadcrumb'>");
        }

        public MvcHtmlString AddCrumb(string url, string title, bool active = false) {
            if (active) {
                _helper.ViewContext.Writer.Write(string.Format("<li class='active'>{0}</li>", title));
            } else {
                _helper.ViewContext.Writer.Write(string.Format("<li><a href='{0}'>{1}</a></li>", url, title));
            }
            
            return new MvcHtmlString(string.Empty);
        }

        public void Dispose() {
            _helper.ViewContext.Writer.Write("</ol>");
        }
    }
}
