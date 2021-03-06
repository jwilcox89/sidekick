﻿using System;
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

        /// <summary>
        ///     Text to append to the end of the element
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public InputGroupBuilder<TModel, TProperty> AppendText(string text)
        {
            _appendText = text;
            return this;
        }

        /// <summary>
        ///     Icon to append to the end of the element
        /// </summary>
        /// <param name="icon"></param>
        /// <returns></returns>
        public InputGroupBuilder<TModel, TProperty> AppendIcon(Icon icon)
        {
            _appendIcon = icon;
            return this;
        }

        /// <summary>
        ///     Icon to append to the end of the element
        /// </summary>
        /// <param name="icon"></param>
        /// <returns></returns>
        public InputGroupBuilder<TModel, TProperty> AppendIcon(string icon)
        {
            _appendIcon = new Icon(icon);
            return this;
        }

        /// <summary>
        ///     Text to prepend to the beginning of the element
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public InputGroupBuilder<TModel, TProperty> PrependText(string text)
        {
            _prependText = text;
            return this;
        }

        /// <summary>
        ///     Icon to prepend to the beginning of the element
        /// </summary>
        /// <param name="icon"></param>
        /// <returns></returns>
        public InputGroupBuilder<TModel, TProperty> PrependIcon(Icon icon)
        {
            _prependIcon = icon;
            return this;
        }

        /// <summary>
        ///     Icon to prepend to the beginning of the element
        /// </summary>
        /// <param name="icon"></param>
        /// <returns></returns>
        public InputGroupBuilder<TModel, TProperty> PrependIcon(string icon)
        {
            _prependIcon = new Icon(icon);
            return this;
        }

        /// <summary>
        ///     Set the size of the input group
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public InputGroupBuilder<TModel, TProperty> InputSize(InputGroupSize size)
        {
            _inputGroupSize = size;
            return this;
        }

        /// <summary>
        ///     Class that will be used to initialize a datetimepicker element
        /// </summary>
        /// <param name="class"></param>
        /// <returns></returns>
        public InputGroupBuilder<TModel, TProperty> DatetimepickerClass(string @class)
        {
            _datetimepickerClass = @class;
            return this;
        }

        /// <summary>
        ///     Id that will be used to initialize a datetimepicker element
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public InputGroupBuilder<TModel, TProperty> DatetimepickerId(string id)
        {
            _datetimepickerId = id;
            return this;
        }

        private MvcHtmlString BuildDropdownInputGroup()
        {
            _helper.WriteLine("<div class='form-group'>");

            if (_label)
                _helper.WriteLine(_helper.LabelFor(_expression, _labelAppend, _required));

            _helper.WriteLine($"<div class='input-group {_inputGroupSize.GetAttribute<HtmlBuilderAttribute>().Class} {_datetimepickerClass}' id='{_datetimepickerId}'>");

            if (_prependIcon != null || !String.IsNullOrEmpty(_prependText))
            {
                _helper.WriteLine("<span class='input-group-addon'>");

                if (_prependIcon != null)
                    _helper.WriteLine(new IconBuilder(_prependIcon).ToHtmlString());

                if (!String.IsNullOrEmpty(_prependText))
                    _helper.WriteLine($" {_prependText}");

                _helper.WriteLine("</span>");
            }

            if (_multiselect)
            {
                _helper.WriteLine(_helper.ListBoxFor(_expression, _selectListItems, BuilderUtils.MergeAttributes(_baseAttributes, _htmlAttributes)));
            }
            else
            {
                _helper.WriteLine(_helper.DropDownListFor(_expression, _selectListItems, _optionLabel, BuilderUtils.MergeAttributes(_baseAttributes, _htmlAttributes)));
            }

            if (_appendIcon != null || !String.IsNullOrEmpty(_appendText))
            {
                _helper.WriteLine("<span class='input-group-addon'>");

                if (_appendIcon != null)
                    _helper.WriteLine(new IconBuilder(_appendIcon).ToHtmlString());

                if (!String.IsNullOrEmpty(_appendText))
                    _helper.WriteLine($" {_appendText}");

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

            if (_label)
                _helper.WriteLine(_helper.LabelFor(_expression, _labelAppend, _required));

            _helper.WriteLine($"<div class='input-group {_inputGroupSize.GetAttribute<HtmlBuilderAttribute>().Class} {_datetimepickerClass}' id='{_datetimepickerId}'>");

            if (_prependIcon != null || !String.IsNullOrEmpty(_prependText))
            {
                _helper.WriteLine("<span class='input-group-addon'>");

                if (_prependIcon != null)
                    _helper.WriteLine(new IconBuilder(_prependIcon).ToHtmlString());

                if (!String.IsNullOrEmpty(_prependText))
                    _helper.WriteLine($" {_prependText}");

                _helper.WriteLine("</span>");
            }

            _helper.WriteLine(_helper.TextBoxFor(_expression, BuilderUtils.MergeAttributes(_baseAttributes, _htmlAttributes)).ToString());

            if (_appendIcon != null || !String.IsNullOrEmpty(_appendText))
            {
                _helper.WriteLine("<span class='input-group-addon'>");

                if (_appendIcon != null)
                    _helper.WriteLine(new IconBuilder(_appendIcon).ToHtmlString());

                if (!String.IsNullOrEmpty(_appendText))
                    _helper.WriteLine($" {_appendText}");

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
            return (_selectListItems == null) ?
                   BuildTextBoxInputGroup().ToString() :
                   BuildDropdownInputGroup().ToString();
        }
    }
}
