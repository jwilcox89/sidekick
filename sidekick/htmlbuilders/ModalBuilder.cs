﻿using System;
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
            _helper.WriteLine(String.Format("<div class='modal fade' id='{0}'>", _model._id));
            _helper.WriteLine(String.Format("<div class='modal-dialog {0}'>", _model._modalSize.GetAttribute<HtmlBuilderAttribute>().Class));
            _helper.WriteLine("<div class='modal-content'>");
            _helper.WriteLine("<div class='modal-header'>");
            _helper.WriteLine("<button type='button' class='close' data-dismiss='modal' aria-label='Close'><span aria-hidden='true'>&times;</span></button>");
            _helper.WriteLine(String.Format("<h4 class='modal-title'>{0} {1}</h4>", new IconBuilder(_model._icon).ToHtmlString(), _model._title));
            _helper.WriteLine("</div>");
        }

        /// <summary>
        ///     Make 'writeBody' parameter true if you want to use the body content inside the Modal object. False if you wish to write the HTML for the modal.
        /// </summary>
        /// <param name="writeBody"></param>
        /// <returns></returns>
        public ModalBody<TModel> BeginBody(bool writeBody = false)
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
                _helper.WriteLine(String.Format("<div id='{0}'></div>", model._errorAreaID));

            if (writeBody)
                _helper.WriteLine(String.Format("<p>{0}</p>", model._body));
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
                    _helper.WriteLine(String.Format("<button type='submit' class='btn btn-{0}'>{1}</button>",
                                            _model._submitColor.GetAttribute<HtmlBuilderAttribute>().Class,
                                            _model._submitText));
                }
                else
                {
                    _helper.WriteLine(String.Format("<button type='submit' class='btn btn-{0}'>{2} {1}</button>",
                        _model._submitColor.GetAttribute<HtmlBuilderAttribute>().Class,
                        _model._submitText,
                        new IconBuilder(_model._submitIcon).ToHtmlString()));
                }
            }

            if (_model._dismissable)
            {
                if (_model._closeIcon == null)
                {
                    _helper.WriteLine(String.Format("<button type='button' class='btn btn-{0}' data-dismiss='modal'>{1}</button>",
                                            _model._closeColor.GetAttribute<HtmlBuilderAttribute>().Class,
                                            _model._closeText));
                }
                else
                {
                    _helper.WriteLine(String.Format("<button type='button' class='btn btn-{0}' data-dismiss='modal'>{2} {1}</button>",
                        _model._closeColor.GetAttribute<HtmlBuilderAttribute>().Class,
                        _model._closeText,
                        new IconBuilder(_model._closeIcon).ToHtmlString()));
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