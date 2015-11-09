using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.UI;
using System.Linq.Expressions;
using System.IO;
using System.Collections.Generic;

namespace sidekick
{
    public class TextAreaBuilder<TModel,TProperty> : BuilderBase<TModel>, IHtmlString
    {
        private TextArea<TModel,TProperty> _model;

        public TextAreaBuilder(HtmlHelper<TModel> helper, Expression<Func<TModel,TProperty>> expression, object htmlAttributes = null)
            : base(helper) {
            _model = new TextArea<TModel,TProperty>(expression, htmlAttributes);
        }

        /// <summary>
        ///     Number of rows in the textarea
        /// </summary>
        /// <param name="rows"></param>
        /// <returns></returns>
        public TextAreaBuilder<TModel,TProperty> Rows(int rows) {
            _model.Rows = rows;
            return this;
        }

        /// <summary>
        ///     Number of columns in the textarea
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        public TextAreaBuilder<TModel,TProperty> Columns(int columns) {
            _model.Columns = columns;
            return this;
        }

        /// <summary>
        ///     Will hide label
        /// </summary>
        /// <returns></returns>
        public TextAreaBuilder<TModel,TProperty> NoLabel() {
            _model.HasLabel = false;
            _model.HasLabelWithColon = false;
            return this;
        }

        /// <summary>
        ///     Show label but without colon
        /// </summary>
        /// <returns></returns>
        public TextAreaBuilder<TModel,TProperty> HasLabelNoColon() {
            _model.HasLabelWithColon = false;
            _model.HasLabel = true;
            return this;
        }

        /// <summary>
        ///     Hide validation
        /// </summary>
        /// <returns></returns>
        public TextAreaBuilder<TModel,TProperty> NoValidation() {
            _model.HasValidation = false;
            return this;
        }

        /// <summary>
        ///     Will add the required '*' next to the label
        /// </summary>
        /// <returns></returns>
        public TextAreaBuilder<TModel,TProperty> IsRequired() {
            _model.IsRequired = true;
            return this;
        }

        private MvcHtmlString CreateTextArea() {
            WriteLine("<div class='form-group'>");

            if (_model.HasLabelWithColon)
                WriteLine(_helper.LabelForWithColon(_model.Expression, _model.IsRequired));

            if (_model.HasLabel)
                WriteLine(_helper.LabelFor(_model.Expression));

            WriteLine(_helper.TextAreaFor(_model.Expression, _model.Rows, _model.Columns, MergeAttributes(_model)));

            if (_model.HasValidation)
                WriteLine(_helper.ValidationMessageFor(_model.Expression));

            WriteLine("</div>");
            return new MvcHtmlString(String.Empty);
        }

        public string ToHtmlString() {
            return CreateTextArea().ToString();
        }
    }
}
