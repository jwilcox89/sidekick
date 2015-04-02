using System.Web.Mvc;

namespace sidekick
{
    public static class HtmlBuilder
    {
        public static ModalBuilder BeginModal(this HtmlHelper helper, IModal modal) {
            return new ModalBuilder(helper, modal);
        }
    }
}
