using System;
using System.Web.Mvc;

namespace sidekick
{
    public class ModalBuilder<TModel> : BuilderBase<TModel>, IDisposable
    {
        private Modal _model;

        public ModalBuilder(HtmlHelper<TModel> helper, Modal modal) 
            : base(helper) {
            _model = modal;
            WriteLine(String.Format("<div class='modal fade' id='{0}'>", _model.ID));
            WriteLine(String.Format("<div class='modal-dialog {0}'>", _model.ModalSize.GetHtmlAttributes<ModalSize>().Class));
            WriteLine("<div class='modal-content'>");
            WriteLine("<div class='modal-header'>");
            WriteLine("<button type='button' class='close' data-dismiss='modal' aria-label='Close'><span aria-hidden='true'>&times;</span></button>");
            WriteLine(String.Format("<h4 class='modal-title'>{0}</h4>", _model.Title));
            WriteLine("</div>");
            WriteLine("<div class='modal-body'>");
            if (!String.IsNullOrEmpty(modal.ErrorAreaID))
                WriteLine(String.Format("<div id='{0}'></div>", modal.ErrorAreaID));
        }

        private MvcHtmlString BuildFooter() {
            WriteLine("<div class='modal-footer'>");

            if (_model.Dismissable)
                WriteLine(String.Format("<button type='button' class='btn btn-{0}' data-dismiss='modal'>{1}</button>", 
                                        _model.CloseColor.GetHtmlAttributes<Colors>().Class, 
                                        _model.CloseText));

            if (_model.ShowSubmitButton)
                WriteLine(String.Format("<button type='submit' class='btn btn-{0}'>{1}</button>", 
                                        _model.SubmitColor.GetHtmlAttributes<Colors>().Class, 
                                        _model.SubmitText));

            WriteLine("</div>");
            return new MvcHtmlString(String.Empty);
        }

        public void Dispose() {
            WriteLine("</div>");

            if (!_model.HideFooter)
                BuildFooter();

            WriteLine("</div></div></div>");
        }
    }
}
