using System;
using System.Web.Mvc;

namespace sidekick
{
    public class ModalBuilder : IDisposable
    {
        private HtmlHelper _helper;
        private IModal _modal;

        public ModalBuilder(HtmlHelper helper, IModal modal) {
            _helper = helper;
            _modal = modal;

            _helper.ViewContext.Writer.Write(string.Format("<div class='modal fade' id='{0}'>", _modal.ID));
            _helper.ViewContext.Writer.Write(string.Format("<div class='modal-dialog {0}'>", Extentions.GetDisplayName<ModalSize>(_modal.ModalSize)));
            _helper.ViewContext.Writer.Write("<div class='modal-content'>");
            _helper.ViewContext.Writer.Write("<div class='modal-header'>");
            _helper.ViewContext.Writer.Write("<button type='button' class='close' data-dismiss='modal' aria-label='Close'><span aria-hidden='true'>&times;</span></button>");
            _helper.ViewContext.Writer.Write(string.Format("<h4 class='modal-title'>{0}</h4>", _modal.Title));
            _helper.ViewContext.Writer.Write("</div>");
        }

        public ModalBody BuildBody() {
            return new ModalBody(_helper, _modal);
        }

        public MvcHtmlString BuildFooter() {
            new ModalFooter(_helper, _modal);
            return new MvcHtmlString(string.Empty);
        }

        public void Dispose() {
            _helper.ViewContext.Writer.Write("</div>");
            _helper.ViewContext.Writer.Write("</div>");
            _helper.ViewContext.Writer.Write("</div>");
        }
    }

    public class ModalBody : IDisposable
    {
        private HtmlHelper _helper;

        public ModalBody(HtmlHelper helper, IModal modal) {
            _helper = helper;
            _helper.ViewContext.Writer.Write("<div class='modal-body'>");

            if (!string.IsNullOrEmpty(modal.ErrorAreaID))
                _helper.ViewContext.Writer.Write(string.Format("<div id='{0}'></div>", modal.ErrorAreaID));
        }

        public void Dispose() {
            _helper.ViewContext.Writer.Write("</div>");
        }
    }

    public class ModalFooter
    {
        public ModalFooter(HtmlHelper helper, IModal modal) {
            helper.ViewContext.Writer.Write("<div class='modal-footer'>");

            if (modal.Dismissable) {
                string closeText = (!string.IsNullOrEmpty(modal.CloseText)) ? modal.CloseText : "Close";
                helper.ViewContext.Writer.Write(string.Format("<button type='button' class='btn btn-default' data-dismiss='modal'>{0}</button>", closeText));
            }

            string submitText = (!string.IsNullOrEmpty(modal.SubmitText)) ? modal.SubmitText : "Submit";
            helper.ViewContext.Writer.Write(string.Format("<button type='submit' class='{0}'>{1}</button>", Extentions.GetDisplayName<ButtonColor>(modal.SubmitColor), submitText));

            helper.ViewContext.Writer.Write("</div>");
        }
    }
}
