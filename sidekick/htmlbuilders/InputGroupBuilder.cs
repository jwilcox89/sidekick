﻿using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.UI;
using System.Linq.Expressions;
using System.IO;

namespace sidekick
{
    public class InputGroupBuilder<TModel,TProperty> : BuilderBase<TModel>, IHtmlString
    {
        private InputGroup<TModel,TProperty> _model;

        public InputGroupBuilder(HtmlHelper<TModel> helper, Expression<Func<TModel,TProperty>> expression, object htmlAttributes)
            : base(helper) {
            _model = new InputGroup<TModel,TProperty>(expression, htmlAttributes);
        }

        /// <summary>
        ///     Show label without colon
        /// </summary>
        /// <returns></returns>
        public InputGroupBuilder<TModel,TProperty> HasLabel() {
            _model.HasLabel = true;
            return this;
        }

        /// <summary>
        ///     Show label with colon
        /// </summary>
        /// <returns></returns>
        public InputGroupBuilder<TModel,TProperty> HasLabelWithColon() {
            _model.HasLabelWithColon = true;
            return this;
        }

        /// <summary>
        ///     Mark field has required
        /// </summary>
        /// <returns></returns>
        public InputGroupBuilder<TModel,TProperty> IsRequired() {
            _model.IsRequired = true;
            return this;
        }

        /// <summary>
        ///     Show validation
        /// </summary>
        /// <returns></returns>
        public InputGroupBuilder<TModel,TProperty> HasValidation() {
            _model.HasValidation = true;
            return this;
        }

        #region Input Group Specific

        public InputGroupBuilder<TModel,TProperty> PrependIcon(string icon) {
            _model.PrependIcon = icon;
            return this;
        }

        public InputGroupBuilder<TModel,TProperty> AppendIcon(string icon) {
            _model.AppendIcon = icon;
            return this;
        }

        public InputGroupBuilder<TModel,TProperty> PrependText(string text) {
            _model.PrependText = text;
            return this;
        }

        public InputGroupBuilder<TModel,TProperty> AppendText(string text) {
            _model.AppendText = text;
            return this;
        }

        public InputGroupBuilder<TModel,TProperty> Size(InputGroupSize size) {
            _model.Size = size;
            return this;
        }

        public InputGroupBuilder<TModel,TProperty> DatetimepickerCss(string @class) {
            _model.DatetimepickerClass = @class;
            return this;
        }

        public InputGroupBuilder<TModel,TProperty> DatetimepickerId(string id) {
            _model.DatetimepickerId = id;
            return this;
        }

        #endregion

        private MvcHtmlString CreateInputGroup() {
            WriteLine("<div class='form-group'>");

            if (_model.HasLabelWithColon)
                WriteLine(_helper.LabelForWithColon(_model.Expression, _model.IsRequired));

            if (_model.HasLabel)
                WriteLine(_helper.LabelFor(_model.Expression, _model.IsRequired));

            WriteLine(String.Format("<div class='input-group {0} {1}' id='{2}'>", _model.Size.GetHtmlAttributes<InputGroupSize>().Class, _model.DatetimepickerClass, _model.DatetimepickerId));

            if (!String.IsNullOrEmpty(_model.PrependIcon) || !String.IsNullOrEmpty(_model.PrependText)) {
                WriteLine("<span class='input-group-addon'>");

                if (!String.IsNullOrEmpty(_model.PrependIcon))
                    WriteLine(String.Format("<i class='{0}'></i>", _model.PrependIcon));

                if (!String.IsNullOrEmpty(_model.PrependText))
                    WriteLine(String.Format(" {0}", _model.PrependText));

                WriteLine("</span>");
            }

            WriteLine(_helper.TextBoxFor(_model.Expression, _model.HtmlAttributes).ToString());

            if (!String.IsNullOrEmpty(_model.AppendIcon) || !String.IsNullOrEmpty(_model.AppendText)) {
                WriteLine("<span class='input-group-addon'>");

                if (!String.IsNullOrEmpty(_model.AppendIcon))
                    WriteLine(String.Format("<i class='{0}'></i>", _model.AppendIcon));

                if (!String.IsNullOrEmpty(_model.AppendText))
                    WriteLine(String.Format(" {0}", _model.AppendText));

                WriteLine("</span>");
            }

            if (_model.HasValidation)
                WriteLine(_helper.ValidationMessageFor(_model.Expression));

            WriteLine("</div>");
            WriteLine("</div>");

            return new MvcHtmlString(String.Empty);
        }

        public string ToHtmlString() {
            return CreateInputGroup().ToString();
        }
    }
}
