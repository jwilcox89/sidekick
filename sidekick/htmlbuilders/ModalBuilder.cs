using System;
using System.Web.Mvc;

namespace sidekick
{
    public class ModalBuilder<TModel> : IDisposable
    {
        private HtmlHelper<TModel> _helper;
        private Modal _model;

        public ModalBuilder(HtmlHelper<TModel> helper, Modal modal)
        {
            _model = modal;
            _helper = helper;
            _helper.WriteLine(String.Format("<div class='modal fade' id='{0}'>", _model._id));
            _helper.WriteLine(String.Format("<div class='modal-dialog {0}'>", _model._modalSize.GetAttribute<ModalSize, HtmlBuilderAttribute>().Class));
            _helper.WriteLine("<div class='modal-content'>");
            _helper.WriteLine("<div class='modal-header'>");
            _helper.WriteLine("<button type='button' class='close' data-dismiss='modal' aria-label='Close'><span aria-hidden='true'>&times;</span></button>");
            _helper.WriteLine(String.Format("<h4 class='modal-title'>{0}</h4>", _model._title));
            _helper.WriteLine("</div>");
        }

        public ModalBody<TModel> BuildBody()
        {
            return new ModalBody<TModel>(_helper, _model);
        }

        public MvcHtmlString BuildFooter()
        {
            _helper.WriteLine("<div class='modal-footer'>");

            if (_model._dismissable)
                _helper.WriteLine(String.Format("<button type='button' class='btn btn-{0}' data-dismiss='modal'>{1}</button>",
                                        _model._closeColor.GetAttribute<Colors, HtmlBuilderAttribute>().Class,
                                        _model._closeText));

            if (_model._showSubmitButton)
                _helper.WriteLine(String.Format("<button type='submit' class='btn btn-{0}'>{1}</button>",
                                        _model._submitColor.GetAttribute<Colors, HtmlBuilderAttribute>().Class,
                                        _model._submitText));

            _helper.WriteLine("</div>");
            return new MvcHtmlString(String.Empty);
        }

        public void Dispose()
        {
            _helper.WriteLine("</div></div></div>");
        }
    }

    public class ModalBody<TModel> : IDisposable
    {
        private HtmlHelper<TModel> _helper;

        public ModalBody(HtmlHelper<TModel> helper, Modal model)
        {
            _helper = helper;
            _helper.WriteLine("<div class='modal-body'>");
            if (!String.IsNullOrEmpty(model._errorAreaID))
                _helper.WriteLine(String.Format("<div id='{0}'></div>", model._errorAreaID));
        }

        public void Dispose()
        {
            _helper.WriteLine("</div>");
        }
    }
}