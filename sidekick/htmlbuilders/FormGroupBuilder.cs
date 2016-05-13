using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web;
using System.Web.Mvc.Html;

namespace sidekick
{
    /// <summary>
    ///     HTML builder for an input element.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <typeparam name="TProperty"></typeparam>
    public class FormGroupBuilder<TModel, TProperty> : FormControl<FormGroupBuilder<TModel, TProperty>>, IHtmlString
    {
        private HtmlHelper<TModel> _helper;
        private Expression<Func<TModel, TProperty>> _expression;

        public FormGroupBuilder(HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, ControlType controlType)
        {
            _helper = helper;
            _expression = expression;
            _type = controlType;
        }

        public FormGroupBuilder(HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, ControlType controlType, IEnumerable<SelectListItem> items, string optionLabel)
        {
            _helper = helper;
            _expression = expression;
            _type = controlType;
            _selectListItems = items;
            _optionLabel = optionLabel;
        }

        private MvcHtmlString BuildTextBoxFormGroup()
        {
            _helper.WriteLine("<div class='form-group'>");

            if (_labelWithColon)
                _helper.WriteLine(_helper.LabelForWithColon(_expression, _required));

            if (_label)
                _helper.WriteLine(_helper.LabelForNoColon(_expression, _required));

            switch (_type)
            {
                case ControlType.Textbox:
                    _helper.WriteLine(_helper.TextBoxFor(_expression, BuilderHelper.MergeAttributes(_baseAttributes, _htmlAttributes)));
                    break;
                case ControlType.Password:
                    _helper.WriteLine(_helper.PasswordFor(_expression, BuilderHelper.MergeAttributes(_baseAttributes, _htmlAttributes)));
                    break;
            }

            if (!String.IsNullOrEmpty(_helpText))
                _helper.WriteLine(String.Format("<span class='help-block'>{0}</span>", _helpText));

            if (_validation)
                _helper.WriteLine(_helper.ValidationMessageFor(_expression));

            _helper.WriteLine("</div>");
            return new MvcHtmlString(String.Empty);
        }

        private MvcHtmlString BuildDropdownFormGroup()
        {
            _helper.WriteLine("<div class='form-group'>");

            if (_labelWithColon)
                _helper.WriteLine(_helper.LabelForWithColon(_expression, _required));

            if (_label)
                _helper.WriteLine(_helper.LabelForNoColon(_expression, _required));

            if (_multiselect)
            {
                _helper.WriteLine(_helper.ListBoxFor(_expression, _selectListItems, BuilderHelper.MergeAttributes(_baseAttributes, _htmlAttributes)));
            }
            else
            {
                _helper.WriteLine(_helper.DropDownListFor(_expression, _selectListItems, _optionLabel, BuilderHelper.MergeAttributes(_baseAttributes, _htmlAttributes)));
            }

            if (!String.IsNullOrEmpty(_helpText))
                _helper.WriteLine(String.Format("<span class='help-block'>{0}</span>", _helpText));

            if (_validation)
                _helper.WriteLine(_helper.ValidationMessageFor(_expression));

            _helper.WriteLine("</div>");
            return new MvcHtmlString(String.Empty);
        }

        private MvcHtmlString CreateTextArea()
        {
            _helper.WriteLine("<div class='form-group'>");

            if (_labelWithColon)
                _helper.WriteLine(_helper.LabelForWithColon(_expression, _required));

            if (_label)
                _helper.WriteLine(_helper.LabelForNoColon(_expression, _required));

            _helper.WriteLine(_helper.TextAreaFor(_expression, _rows, _columns, BuilderHelper.MergeAttributes(_baseAttributes, _htmlAttributes)));

            if (!String.IsNullOrEmpty(_helpText))
                _helper.WriteLine(String.Format("<span class='help-block'>{0}</span>", _helpText));

            if (_validation)
                _helper.WriteLine(_helper.ValidationMessageFor(_expression));

            _helper.WriteLine("</div>");
            return new MvcHtmlString(String.Empty);
        }

        public string ToHtmlString()
        {
            switch (_type)
            {
                case ControlType.Textbox:
                    return (_selectListItems == null) ? BuildTextBoxFormGroup().ToString() : BuildDropdownFormGroup().ToString();
                case ControlType.Password:
                    return BuildTextBoxFormGroup().ToString();
                case ControlType.TextArea:
                    return CreateTextArea().ToString();
            }

            return String.Empty;
        }
    }
}
