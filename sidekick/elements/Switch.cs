namespace sidekick
{
    /// <summary>
    ///     Bootstrap 'switch' element (http://www.bootstrap-switch.org/).
    /// </summary>
    public class Switch
    {
        internal string _elementName;
        internal bool _state;
        internal SwitchSize? _size;
        internal bool _animate;
        internal bool _disabled;
        internal bool _readOnly;
        internal bool _indeterminate;
        internal bool _inverse;
        internal bool _radioAllOff;
        internal Colors? _onColor;
        internal Colors? _offColor;
        internal string _onText;
        internal string _offText;
        internal string _labelText;
        internal string _handleWidth;
        internal string _labelWidth;
        internal string _baseClass;
        internal string _wrapperClass;

        public Switch()
        {
            _animate = true;
        }

        /// <summary>
        ///     Set the global class prefix
        /// </summary>
        /// <param name="baseClass"></param>
        public Switch(string baseClass)
        {
            _baseClass = baseClass;
            _animate = true;
        }

        /// <summary>
        ///     The checkbox size
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public Switch Size(SwitchSize size)
        {
            _size = size;
            return this;
        }

        /// <summary>
        ///     Animate the switch.
        /// </summary>
        /// <returns></returns>
        public Switch NoAnimation()
        {
            _animate = false;
            return this;
        }

        /// <summary>
        ///     Disable state
        /// </summary>
        /// <returns></returns>
        public Switch Disable()
        {
            _disabled = true;
            return this;
        }

        /// <summary>
        ///     Readonly state
        /// </summary>
        /// <returns></returns>
        public Switch ReadyOnly()
        {
            _readOnly = true;
            return this;
        }

        /// <summary>
        ///     Indeterminate state
        /// </summary>
        /// <returns></returns>
        public Switch Indeterminate()
        {
            _indeterminate = true;
            return this;
        }

        /// <summary>
        ///     Inverse switch direction
        /// </summary>
        /// <returns></returns>
        public Switch Inverse()
        {
            _inverse = true;
            return this;
        }

        /// <summary>
        ///     Allow this radio button to be unchecked by the user
        /// </summary>
        /// <returns></returns>
        public Switch RadioAllOff()
        {
            _radioAllOff = true;
            return this;
        }

        /// <summary>
        ///     Color of the left side of the switch
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public Switch OnColor(Colors color)
        {
            _onColor = color;
            return this;
        }

        /// <summary>
        ///     Color of the right side of the switch
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public Switch OffColor(Colors color)
        {
            _offColor = color;
            return this;
        }

        /// <summary>
        ///     Text of the left side of the switch
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public Switch OnText(string text)
        {
            _onText = text;
            return this;
        }

        /// <summary>
        ///     Text of the right side of the switch
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public Switch OffText(string text)
        {
            _offText = text;
            return this;
        }

        /// <summary>
        ///     Text of the center handle of the switch
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public Switch LabelText(string text)
        {
            _labelText = text;
            return this;
        }

        /// <summary>
        ///     Width of the left and right sides in pixels
        /// </summary>
        /// <param name="width"></param>
        /// <returns></returns>
        public Switch HandleWidth(int width)
        {
            _handleWidth = width.ToString();
            return this;
        }

        /// <summary>
        ///     Width of the center handle in pixels
        /// </summary>
        /// <param name="width"></param>
        /// <returns></returns>
        public Switch LabelWidth(int width)
        {
            _labelWidth = width.ToString();
            return this;
        }

        /// <summary>
        ///     Container element class(es)
        /// </summary>
        /// <param name="class"></param>
        /// <returns></returns>
        public Switch WrapperClass(string @class)
        {
            _wrapperClass = @class;
            return this;
        }
    }
}
