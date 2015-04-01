using System;
using System.Web.Mvc;

namespace sidekick
{
    public class ModalBuilder : IDisposable
    {
        private HtmlHelper _helper;

        public ModalBuilder(HtmlHelper helper, string modalID, string modalTitle) {
            _helper = helper;

            _helper.ViewContext.Writer.Write(string.Format("<div class='modal fade' id='{0}'>", modalID));
            _helper.ViewContext.Writer.Write("<div class='modal-dialog'>");
            _helper.ViewContext.Writer.Write("<div class='modal-content'>");
            _helper.ViewContext.Writer.Write("<div class='modal-header'>");
            _helper.ViewContext.Writer.Write("<button type='button' class='close' data-dismiss='modal' aria-label='Close'><span aria-hidden='true'>&times;</span></button>");
            _helper.ViewContext.Writer.Write(string.Format("<h4 class='modal-title'>{0}</h4>", modalTitle));
            _helper.ViewContext.Writer.Write("</div>");
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
