using System;
using System.Web.Mvc;

namespace sidekick
{
    /// <summary>
    ///     HTML builder for a Bootstrap 'Modal' element.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class ModalBuilder<TModel> : IDisposable
    {
        private HtmlHelper<TModel> _helper;
        private Modal _model;

        public ModalBuilder(HtmlHelper<TModel> helper, Modal modal)
        {
            _model = modal;
            _helper = helper;
            _helper.WriteLine($"<div class='modal fade' id='{_model._id}'>");
            _helper.WriteLine($"<div class='modal-dialog {_model._modalSize.GetAttribute<HtmlBuilderAttribute>().Class}'>");
            _helper.WriteLine("<div class='modal-content'>");
            _helper.WriteLine("<div class='modal-header'>");
            _helper.WriteLine("<button type='button' class='close' data-dismiss='modal' aria-label='Close'><span aria-hidden='true'>&times;</span></button>");
            _helper.WriteLine($"<h4 class='modal-title'>{new IconBuilder(_model._icon).ToHtmlString()} {_model._title}</h4>");
            _helper.WriteLine("</div>");
        }

        /// <summary>
        ///     Begins the body section of the modal
        /// </summary>
        /// <returns></returns>
        public ModalBody<TModel> BeginBody()
        {
            return BeginBody(false);
        }

        /// <summary>
        ///     Make 'writeBody' parameter true if you want to use the body content inside the Modal object. False if you wish to write the HTML for the modal.
        /// </summary>
        /// <param name="writeBody"></param>
        /// <returns></returns>
        public ModalBody<TModel> BeginBody(bool writeBody)
        {
            return new ModalBody<TModel>(_helper, _model, writeBody);
        }

        public void Dispose()
        {
            _helper.WriteLine("</div></div></div>");
        }
    }

    public class ModalBody<TModel> : IDisposable
    {
        private HtmlHelper<TModel> _helper;
        private Modal _model;

        public ModalBody(HtmlHelper<TModel> helper, Modal model, bool writeBody)
        {
            _helper = helper;
            _model = model;
            _helper.WriteLine("<div class='modal-body'>");
            if (!String.IsNullOrEmpty(model._errorAreaID))
                _helper.WriteLine($"<div id='{model._errorAreaID}'></div>");

            if (writeBody)
                _helper.WriteLine($"<p>{model._body}</p>");
        }

        /// <summary>
        ///     Build the footer for the modal
        /// </summary>
        /// <returns></returns>
        public ModalBody<TModel> HasFooter()
        {
            _model._hasFooter = true;
            return this;
        }

        private void BuildFooter()
        {
            _helper.WriteLine("<div class='modal-footer'>");

            if (_model._showSubmitButton)
            {
                if (_model._submitIcon == null)
                {
                    _helper.WriteLine($"<button type='submit' class='btn btn-{_model._submitColor.GetAttribute<HtmlBuilderAttribute>().Class}'>{_model._submitText}</button>");
                }
                else
                {
                    _helper.WriteLine($"<button type='submit' class='btn btn-{_model._submitColor.GetAttribute<HtmlBuilderAttribute>().Class}'>{new IconBuilder(_model._submitIcon).ToHtmlString()} {_model._submitText} </button>");
                }
            }

            if (_model._dismissable)
            {
                if (_model._closeIcon == null)
                {
                    _helper.WriteLine($"<button type='button' class='btn btn-{_model._closeColor.GetAttribute<HtmlBuilderAttribute>().Class}' data-dismiss='modal'>{_model._closeText}</button>");
                }
                else
                {
                    _helper.WriteLine($"<button type='button' class='btn btn-{_model._closeColor.GetAttribute<HtmlBuilderAttribute>().Class}' data-dismiss='modal'>{new IconBuilder(_model._closeIcon).ToHtmlString()} {_model._closeText}</button>");
                }
            }

            _helper.WriteLine("</div>");
        }

        public void Dispose()
        {
            _helper.WriteLine("</div>");
            if (_model._hasFooter)
                BuildFooter();
        }
    }
}