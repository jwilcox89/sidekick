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
        internal bool _labelWithColon;
        internal bool _validation;
        internal bool _required;
        internal string _helpText;
        internal IEnumerable<SelectListItem> _selectListItems;
        internal bool _multiselect;
        internal string _optionLabel;
        internal string _appendText;
        internal string _prependText;
        internal string _appendIcon;
        internal string _prependIcon;
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
        ///     Show label without a semi colon
        /// </summary>
        /// <returns></returns>
        public T HasLabel()
        {
            _label = true;
            _labelWithColon = false;
            return (T)this;
        }

        /// <summary>
        ///     Show label with a semi colon
        /// </summary>
        /// <returns></returns>
        public T HasLabelWithColon()
        {
            _label = false;
            _labelWithColon = true;
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
        ///     For use with the textarea, number of rows to display
        /// </summary>
        /// <param name="rows"></param>
        /// <returns></returns>
        public T Rows(int rows)
        {
            _rows = rows;
            return (T)this;
        }

        /// <summary>
        ///     For use with the textarea, number of columns to display
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
