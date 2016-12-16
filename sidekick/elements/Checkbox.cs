namespace sidekick
{
    /// <summary>
    ///     Checkbox HTML element
    /// </summary>
    public class Checkbox
    {
        internal CheckboxType _type;
        internal bool _label;
        internal string _appendText;
        internal bool _required;
        internal object _htmlAttributes;

        /// <summary>
        ///     Display a label next to the checkbox
        /// </summary>
        /// <returns></returns>
        public Checkbox HasLabel()
        {
            _label = true;
            return this;
        }

        /// <summary>
        ///     Display a label next to the checkbox
        /// </summary>
        /// <returns></returns>
        public Checkbox HasLabel(string appendText)
        {
            _label = true;
            _appendText = appendText;
            return this;
        }

        /// <summary>
        ///     Show '*' next to label to indicate required field
        /// </summary>
        /// <returns></returns>
        public Checkbox IsRequired()
        {
            _required = true;
            return this;
        }

        /// <summary>
        ///     Additional HTML attributes for checkbox
        /// </summary>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public Checkbox HtmlAttributes(object attributes)
        {
            _htmlAttributes = attributes;
            return this;
        }
    }
}
