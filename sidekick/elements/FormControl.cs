using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Web.Mvc;

namespace sidekick
{
    /// <summary>
    ///     Base attributes of all form controls
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FormControl<T> 
        where T : FormControl<T>
    {
        internal object _htmlAttributes;
        internal object _baseAttributes;
        internal ControlType _type;
        internal bool _label;
        internal string _labelAppend;
        internal bool _validation;
        internal bool _required;
        internal string _helpText;
        internal IEnumerable<SelectListItem> _selectListItems;
        internal bool _multiselect;
        internal string _optionLabel;
        internal string _appendText;
        internal string _prependText;
        internal Icon _appendIcon;
        internal Icon _prependIcon;
        internal InputGroupSize _inputGroupSize;
        internal string _datetimepickerClass;
        internal string _datetimepickerId;
        internal int _rows;
        internal int _columns;

        public FormControl()
        {
            _inputGroupSize = InputGroupSize.Regular;
            if (_baseAttributes == null)
                _baseAttributes = new { @class = "form-control" };
        }

        /// <summary>
        ///     Show '*' next to label to indicate required field
        /// </summary>
        /// <returns></returns>
        public T IsRequired()
        {
            _required = true;
            return (T)this;
        }

        /// <summary>
        ///     Show label
        /// </summary>
        /// <returns></returns>
        public T HasLabel()
        {
            _label = true;
            return (T)this;
        }

        /// <summary>
        ///     Show label with text appended to it (ex ':' or '?')
        /// </summary>
        /// <param name="append"></param>
        /// <returns></returns>
        public T HasLabel(string append)
        {
            _label = true;
            _labelAppend = append;
            return (T)this;
        }

        /// <summary>
        ///     Validation will show if there is a validation error
        /// </summary>
        /// <returns></returns>
        public T HasValidation()
        {
            _validation = true;
            return (T)this;
        }

        /// <summary>
        ///     Set the help text below the element
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public T HelpText(string text)
        {
            _helpText = text;
            return (T)this;
        }

        /// <summary>
        ///     Additional html attributes for the element
        /// </summary>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public T HtmlAttributes(object htmlAttributes)
        {
            _htmlAttributes = htmlAttributes;
            return (T)this;
        }

        /// <summary>
        ///     Number of rows to display
        ///     <para>*Note: Textarea only</para>
        /// </summary>
        /// <param name="rows"></param>
        /// <returns></returns>
        public T Rows(int rows)
        {
            _rows = rows;
            return (T)this;
        }

        /// <summary>
        ///     Number of columns to display
        ///     <para>*Note: Textarea only</para>
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        public T Columns(int columns)
        {
            _columns = columns;
            return (T)this;
        }

        /// <summary>
        ///     For making a dropdown list multiselect
        /// </summary>
        /// <returns></returns>
        public T Multiselect()
        {
            _multiselect = true;
            return (T)this;
        }
    }
}
