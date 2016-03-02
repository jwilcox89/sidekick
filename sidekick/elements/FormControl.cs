using System.Collections.Generic;
using System.Web.Mvc;

namespace sidekick
{
    public class FormControl<T> where T : FormControl<T>
    {
        /// <summary>
        ///     An object that contains the HTML attributes to set for the element.
        /// </summary>
        internal object _htmlAttributes;

        /// <summary>
        ///     Base html attributes
        /// </summary>
        internal object _baseAttributes;

        /// <summary>
        ///     Control type for the form control
        /// </summary>
        internal ControlType _type;

        /// <summary>
        ///     True if label has no colon.
        /// </summary>
        internal bool _label;

        /// <summary>
        ///     True if label requires a colon.
        /// </summary>
        internal bool _labelWithColon;

        /// <summary>
        ///     True if from group requires validation.
        /// </summary>
        internal bool _validation;

        /// <summary>
        ///     True if the field is required and you want to include a required '*' next to the label.
        /// </summary>
        internal bool _required;

        /// <summary>
        ///     Help text that will show below the form control
        /// </summary>
        internal string _helpText;

        /// <summary>
        ///     List of items for a dropdown list
        /// </summary>
        internal IEnumerable<SelectListItem> _selectListItems;

        /// <summary>
        ///     Text for top element of dropdown list
        /// </summary>
        internal string _optionLabel;

        /// <summary>
        ///     Text to append to the input group
        /// </summary>
        internal string _appendText;

        /// <summary>
        ///     Text to prepend to the input group
        /// </summary>
        internal string _prependText;

        /// <summary>
        ///     Icon to append to the input group
        /// </summary>
        internal string _appendIcon;

        /// <summary>
        ///     Icon to prepend to the input group
        /// </summary>
        internal string _prependIcon;

        /// <summary>
        ///     Size of the input group
        /// </summary>
        internal InputGroupSize _inputGroupSize;

        /// <summary>
        ///     Css class for datetimepicker
        /// </summary>
        internal string _datetimepickerClass;

        /// <summary>
        ///     Id for datetimepicker
        /// </summary>
        internal string _datetimepickerId;

        /// <summary>
        ///     Number of rows for text area
        /// </summary>
        internal int _rows;

        /// <summary>
        ///     Number of columns for the text area
        /// </summary>
        internal int _columns;

        public T IsRequired()
        {
            _required = true;
            return (T)this;
        }

        public T HasLabel()
        {
            _label = true;
            _labelWithColon = false;
            return (T)this;
        }

        public T HasLabelWithColon()
        {
            _label = false;
            _labelWithColon = true;
            return (T)this;
        }

        public T HasValidation()
        {
            _validation = true;
            return (T)this;
        }

        public T HelpText(string text)
        {
            _helpText = text;
            return (T)this;
        }

        public T HtmlAttributes(object htmlAttributes)
        {
            _htmlAttributes = htmlAttributes;
            return (T)this;
        }

        public T Rows(int rows)
        {
            _rows = rows;
            return (T)this;
        }

        public T Columns(int columns)
        {
            _columns = columns;
            return (T)this;
        }

        public FormControl()
        {
            _inputGroupSize = InputGroupSize.Regular;
            if (_baseAttributes == null)
                _baseAttributes = new { @class = "form-control" };
        }
    }
}
