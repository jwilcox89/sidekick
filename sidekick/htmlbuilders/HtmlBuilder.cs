using System.Web.Mvc;

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

        public static TabBuilder BeginPanel(this HtmlHelper helper) {
            return new TabBuilder(helper);
        }
    }
}
