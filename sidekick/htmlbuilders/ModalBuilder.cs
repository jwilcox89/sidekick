using System;
using System.Web.Mvc;

namespace sidekick
{
    public class ModalBuilder<TModel> : BuilderBase<TModel>, IDisposable
    {
        private Modal _modal;

        public ModalBuilder(HtmlHelper<TModel> helper, Modal modal)
            : base(helper)
        {
            _modal = modal;
            WriteLine(String.Format("<div class='modal fade' id='{0}'>", _modal.ID));
            WriteLine(String.Format("<div class='modal-dialog {0}'>", _modal.ModalSize.GetAttribute<ModalSize, HtmlBuilderAttribute>().Class));
            WriteLine("<div class='modal-content'>");
            WriteLine("<div class='modal-header'>");
            WriteLine("<button type='button' class='close' data-dismiss='modal' aria-label='Close'><span aria-hidden='true'>&times;</span></button>");
            WriteLine(String.Format("<h4 class='modal-title'>{0}</h4>", _modal.Title));
            WriteLine("</div>");
        }

        public ModalBody<TModel> BuildBody()
        {
            return new ModalBody<TModel>(Helper, _modal);
        }

        public MvcHtmlString BuildFooter()
        {
            WriteLine("<div class='modal-footer'>");

            if (_modal.Dismissable)
                WriteLine(String.Format("<button type='button' class='btn btn-{0}' data-dismiss='modal'>{1}</button>",
                                        _modal.CloseColor.GetAttribute<Colors, HtmlBuilderAttribute>().Class,
                                        _modal.CloseText));

            if (_modal.ShowSubmitButton)
                WriteLine(String.Format("<button type='submit' class='btn btn-{0}'>{1}</button>",
                                        _modal.SubmitColor.GetAttribute<Colors, HtmlBuilderAttribute>().Class,
                                        _modal.SubmitText));

            WriteLine("</div>");
            return new MvcHtmlString(String.Empty);
        }

        public void Dispose()
        {
            WriteLine("</div></div></div>");
        }
    }

    public class ModalBody<TModel> : BuilderBase<TModel>, IDisposable
    {
        public ModalBody(HtmlHelper<TModel> helper, Modal modal)
            : base(helper)
        {
            WriteLine("<div class='modal-body'>");
            if (!String.IsNullOrEmpty(modal.ErrorAreaID))
                WriteLine(String.Format("<div id='{0}'></div>", modal.ErrorAreaID));
        }

        public void Dispose()
        {
            WriteLine("</div>");
        }
    }
}
