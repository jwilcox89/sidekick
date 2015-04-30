using System;
using System.Web.Mvc;
using System.Linq.Expressions;

namespace sidekick
{
    public static class HtmlBuilder
    {
        public static ModalBuilder BeginModal(this HtmlHelper helper, IModal modal) {
            return new ModalBuilder(helper, modal);
        }

        public static AlertBuilder BeginAlert(this HtmlHelper helper, IAlert alert) {
            return new AlertBuilder(helper, alert, true);
        }

        public static MvcHtmlString BuildAlert(this HtmlHelper helper, IAlert alert) {
            new AlertBuilder(helper, alert, false);
            return new MvcHtmlString(string.Empty);
        }

        public static TabBuilder BeginTabs(this HtmlHelper helper) {
            return new TabBuilder(helper);
        }

        public static PanelBuilder BeginPanel(this HtmlHelper helper, IPanel panel) {
            return new PanelBuilder(helper, panel);
        }

        public static StepsBuilder BeginSteps(this HtmlHelper helper, int totalSteps) {
            return new StepsBuilder(helper, totalSteps);
        }

        public static BreadcrumbBuilder BeginBreadcrumbs(this HtmlHelper helper) {
            return new BreadcrumbBuilder(helper);
        }
    }
}
