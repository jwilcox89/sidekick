using System.Web.Mvc;

namespace sidekick
{
    public static class HtmlBuilder
    {
        public static ModalBuilder BeginModal(this HtmlHelper helper, string modalID, string modalTitle) {
            return new ModalBuilder(helper, modalID, modalTitle);
        }

        public static ModalBody BeginModalBody(this HtmlHelper helper, string errorAreaID = null) {
            return new ModalBody(helper, errorAreaID);
        }

        public static ModalFooter BeginModalFooter(this HtmlHelper helper, string submitText, ButtonColor submitColor = ButtonColor.Primary) {
            return new ModalFooter(helper, submitText, submitColor);
        }
    }
}
