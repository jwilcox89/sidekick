namespace sidekick
{
    /// <summary>
    ///     Checkbox HTML element
    /// </summary>
    public class Checkbox
    {
        internal CheckboxType _type;
        internal bool _label;
        internal bool _labelWithColon;
        internal bool _isRequired;
        internal object _htmlAttributes;

        /// <summary>
        ///     Display a label next to the checkbox
        /// </summary>
        /// <returns></returns>
        public Checkbox HasLabel()
        {
            _label = true;
            _labelWithColon = false;
            return this;
        }

        /// <summary>
        ///     Display a label with a colon next to the checkbox
        /// </summary>
        /// <returns></returns>
        public Checkbox HasLabelWithColon()
        {
            _label = false;
            _labelWithColon = true;
            return this;
        }

        /// <summary>
        ///     Show '*' next to label to indicate required field
        /// </summary>
        /// <returns></returns>
        public Checkbox IsRequired()
        {
            _isRequired = true;
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
