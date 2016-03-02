using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web;
using System.Web.Mvc.Html;

namespace sidekick
{
    public class InputGroupBuilder<TModel, TProperty> : FormControl<InputGroupBuilder<TModel, TProperty>>, IHtmlString
    {
        private HtmlHelper<TModel> _helper;
        private Expression<Func<TModel, TProperty>> _expression;

        public InputGroupBuilder(HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression)
        {
            _helper = helper;
            _expression = expression;
        }

        public InputGroupBuilder(HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> items, string optionLabel)
        {
            _helper = helper;
            _expression = expression;
            _selectListItems = items;
            _optionLabel = optionLabel;
        }

        public InputGroupBuilder<TModel, TProperty> AppendText(string text)
        {
            _appendText = text;
            return this;
        }

        public InputGroupBuilder<TModel, TProperty> AppendIcon(string icon)
        {
            _appendIcon = icon;
            return this;
        }

        public InputGroupBuilder<TModel, TProperty> PrependText(string text)
        {
            _prependText = text;
            return this;
        }

        public InputGroupBuilder<TModel, TProperty> PrependIcon(string icon)
        {
            _prependIcon = icon;
            return this;
        }

        public InputGroupBuilder<TModel, TProperty> InputSize(InputGroupSize size)
        {
            _inputGroupSize = size;
            return this;
        }

        public InputGroupBuilder<TModel, TProperty> DatetimepickerClass(string @class)
        {
            _datetimepickerClass = @class;
            return this;
        }

        public InputGroupBuilder<TModel, TProperty> DatetimepickerId(string id)
        {
            _datetimepickerId = id;
            return this;
        }

        private MvcHtmlString BuildDropdownInputGroup()
        {
            _helper.WriteLine("<div class='form-group'>");

            if (_labelWithColon)
                _helper.WriteLine(_helper.LabelForWithColon(_expression, _required));

            if (_label)
                _helper.WriteLine(_helper.LabelFor(_expression, _required));

            _helper.WriteLine(String.Format("<div class='input-group {0} {1}' id='{2}'>", _inputGroupSize.GetAttribute<InputGroupSize, HtmlBuilderAttribute>().Class, _datetimepickerClass, _datetimepickerId));

            if (!String.IsNullOrEmpty(_prependIcon) || !String.IsNullOrEmpty(_prependText))
            {
                _helper.WriteLine("<span class='input-group-addon'>");

                if (!String.IsNullOrEmpty(_prependIcon))
                    _helper.WriteLine(String.Format("<i class='{0}'></i>", _prependIcon));

                if (!String.IsNullOrEmpty(_prependText))
                    _helper.WriteLine(String.Format(" {0}", _prependText));

                _helper.WriteLine("</span>");
            }

            _helper.WriteLine(_helper.DropDownListFor(_expression, _selectListItems, _optionLabel, BuilderHelper.MergeAttributes(_baseAttributes, _htmlAttributes)).ToString());

            if (!String.IsNullOrEmpty(_appendIcon) || !String.IsNullOrEmpty(_appendText))
            {
                _helper.WriteLine("<span class='input-group-addon'>");

                if (!String.IsNullOrEmpty(_appendIcon))
                    _helper.WriteLine(String.Format("<i class='{0}'></i>", _appendIcon));

                if (!String.IsNullOrEmpty(_appendText))
                    _helper.WriteLine(String.Format(" {0}", _appendText));

                _helper.WriteLine("</span>");
            }

            _helper.WriteLine("</div>");

            if (_validation)
                _helper.WriteLine(_helper.ValidationMessageFor(_expression));

            _helper.WriteLine("</div>");

            return new MvcHtmlString(String.Empty);
        }

        private MvcHtmlString BuildTextBoxInputGroup()
        {
            _helper.WriteLine("<div class='form-group'>");

            if (_labelWithColon)
                _helper.WriteLine(_helper.LabelForWithColon(_expression, _required));

            if (_label)
                _helper.WriteLine(_helper.LabelFor(_expression, _required));

            _helper.WriteLine(String.Format("<div class='input-group {0} {1}' id='{2}'>", _inputGroupSize.GetAttribute<InputGroupSize, HtmlBuilderAttribute>().Class, _datetimepickerClass, _datetimepickerId));

            if (!String.IsNullOrEmpty(_prependIcon) || !String.IsNullOrEmpty(_prependText))
            {
                _helper.WriteLine("<span class='input-group-addon'>");

                if (!String.IsNullOrEmpty(_prependIcon))
                    _helper.WriteLine(String.Format("<i class='{0}'></i>", _prependIcon));

                if (!String.IsNullOrEmpty(_prependText))
                    _helper.WriteLine(String.Format(" {0}", _prependText));

                _helper.WriteLine("</span>");
            }

            _helper.WriteLine(_helper.TextBoxFor(_expression, BuilderHelper.MergeAttributes(_baseAttributes, _htmlAttributes)).ToString());

            if (!String.IsNullOrEmpty(_appendIcon) || !String.IsNullOrEmpty(_appendText))
            {
                _helper.WriteLine("<span class='input-group-addon'>");

                if (!String.IsNullOrEmpty(_appendIcon))
                    _helper.WriteLine(String.Format("<i class='{0}'></i>", _appendIcon));

                if (!String.IsNullOrEmpty(_appendText))
                    _helper.WriteLine(String.Format(" {0}", _appendText));

                _helper.WriteLine("</span>");
            }

            _helper.WriteLine("</div>");

            if (_validation)
                _helper.WriteLine(_helper.ValidationMessageFor(_expression));

            _helper.WriteLine("</div>");

            return new MvcHtmlString(String.Empty);
        }

        public string ToHtmlString()
        {
            return (_selectListItems == null) ? BuildTextBoxInputGroup().ToString() : BuildDropdownInputGroup().ToString();
        }
    }
}
