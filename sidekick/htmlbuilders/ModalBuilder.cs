using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            _helper.ViewContext.Writer.Write("<div class='modal-dialog'>");
            _helper.ViewContext.Writer.Write("<div class='modal-content'>");
            _helper.ViewContext.Writer.Write("<div class='modal-header'>");
            _helper.ViewContext.Writer.Write("<button type='button' class='close' data-dismiss='modal' aria-label='Close'><span aria-hidden='true'>&times;</span></button>");
            _helper.ViewContext.Writer.Write(string.Format("<h4 class='modal-title'>{0}</h4>", _modal.Title));
            _helper.ViewContext.Writer.Write("</div>");
        }

        public ModalBody BuildBody() {
            return new ModalBody(_helper, _modal.ErrorAreaID);
        }

        public ModalFooter BuildFooter() {
            return new ModalFooter(_helper, _modal.SubmitText, _modal.SubmitColor);
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

        public ModalBody(HtmlHelper helper, string errorAreaID = null) {
            _helper = helper;
            _helper.ViewContext.Writer.Write("<div class='modal-body'>");

            if (!string.IsNullOrEmpty(errorAreaID))
                _helper.ViewContext.Writer.Write(string.Format("<div id='{0}'></div>", errorAreaID));
        }

        public void Dispose() {
            _helper.ViewContext.Writer.Write("</div>");
        }
    }

    public class ModalFooter : IDisposable
    {
        private HtmlHelper _helper;

        public ModalFooter(HtmlHelper helper, string submitText, ButtonColor submitColor) {
            _helper = helper;

            _helper.ViewContext.Writer.Write("<div class='modal-footer'>");
            _helper.ViewContext.Writer.Write("<button type='button' class='btn btn-default' data-dismiss='modal'>Close</button>");
            _helper.ViewContext.Writer.Write(string.Format("<button type='submit' class='{0}'>{1}</button>", HtmlConverters.ButtonColorConverter(submitColor), submitText));
        }

        public void Dispose() {
            _helper.ViewContext.Writer.Write("</div>");
        }
    }
}
