using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace sidekick
{
    public class FormGroupBuilder<TModel, TProperty> : BuilderBase<TModel>, IHtmlString
    {
        private FormGroup<TModel, TProperty> _model;

        public FormGroupBuilder(HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, object textboxHtmlAttributes)
            : base(helper)
        {
            _model = new FormGroup<TModel, TProperty>(expression, textboxHtmlAttributes);
        }

        public FormGroupBuilder(HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> listItems, string optionLabel, object textboxHtmlAttributes)
            : base(helper)
        {
            _model = new FormGroup<TModel, TProperty>(expression, listItems, optionLabel, textboxHtmlAttributes);
        }

        /// <summary>
        ///     Will hide label
        /// </summary>
        /// <returns></returns>
        public FormGroupBuilder<TModel, TProperty> NoLabel()
        {
            _model.HasLabel = false;
            _model.HasLabelWithColon = false;
            return this;
        }

        /// <summary>
        ///     Show label but without colon
        /// </summary>
        /// <returns></returns>
        public FormGroupBuilder<TModel, TProperty> HasLabelNoColon()
        {
            _model.HasLabelWithColon = false;
            _model.HasLabel = true;
            return this;
        }

        /// <summary>
        ///     Hide validation
        /// </summary>
        /// <returns></returns>
        public FormGroupBuilder<TModel, TProperty> NoValidation()
        {
            _model.HasValidation = false;
            return this;
        }

        /// <summary>
        ///     Will add the required '*' next to the label
        /// </summary>
        /// <returns></returns>
        public FormGroupBuilder<TModel, TProperty> IsRequired()
        {
            _model.IsRequired = true;
            return this;
        }

        /// <summary>
        ///     Help text that will show below the form control
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public FormGroupBuilder<TModel, TProperty> HelpText(string text)
        {
            _model.HelpText = text;
            return this;
        }

        private MvcHtmlString CreateFormGroup()
        {
            return (_model.SelectListItems == null) ? BuildTextBoxFormGroup() : BuildDropdownFormGroup();
        }

        private MvcHtmlString BuildTextBoxFormGroup()
        {
            WriteLine("<div class='form-group'>");

            if (_model.HasLabelWithColon)
                WriteLine(Helper.LabelForWithColon(_model.Expression, _model.IsRequired));

            if (_model.HasLabel)
                WriteLine(Helper.LabelFor(_model.Expression));

            WriteLine(Helper.TextBoxFor(_model.Expression, MergeAttributes(_model)));

            if (!String.IsNullOrEmpty(_model.HelpText))
                WriteLine(String.Format("<span class='help-block'>{0}</span>", _model.HelpText));

            if (_model.HasValidation)
                WriteLine(Helper.ValidationMessageFor(_model.Expression));

            WriteLine("</div>");
            return new MvcHtmlString(String.Empty);
        }

        private MvcHtmlString BuildDropdownFormGroup()
        {
            WriteLine("<div class='form-group'>");

            if (_model.HasLabelWithColon)
                WriteLine(Helper.LabelForWithColon(_model.Expression, _model.IsRequired));

            if (_model.HasLabel)
                WriteLine(Helper.LabelFor(_model.Expression));

            WriteLine(Helper.DropDownListFor(_model.Expression, _model.SelectListItems, _model.OptionLabel, MergeAttributes(_model)));

            if (!String.IsNullOrEmpty(_model.HelpText))
                WriteLine(String.Format("<span class='help-block'>{0}</span>", _model.HelpText));

            if (_model.HasValidation)
                WriteLine(Helper.ValidationMessageFor(_model.Expression));

            WriteLine("</div>");
            return new MvcHtmlString(String.Empty);
        }

        public string ToHtmlString()
        {
            return CreateFormGroup().ToString();
        }
    }
}
