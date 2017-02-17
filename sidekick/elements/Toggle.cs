namespace sidekick
{
    /// <summary>
    ///     Toggle element
    /// </summary>
    public class Toggle
    {
        internal string _onText;
        internal string _offText;
        internal ToggleSize? _size;
        internal Colors? _onStyle;
        internal Colors? _offStyle;
        internal string _customClass;
        internal int? _width;
        internal int? _height;

        /// <summary>
        ///     Text that will display when toggle is on
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public Toggle OnText(string text)
        {
            _onText = text;
            return this;
        }

        /// <summary>
        ///     Text that will display when toggle is off
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public Toggle OffText(string text)
        {
            _offText = text;
            return this;
        }

        /// <summary>
        ///     Size of the toggle
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public Toggle Size(ToggleSize size)
        {
            _size = size;
            return this;
        }

        /// <summary>
        ///     Color when toggle is on
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public Toggle OnStyle(Colors color)
        {
            _onStyle = color;
            return this;
        }

        /// <summary>
        ///     Color when toggle is off
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public Toggle OffStyle(Colors color)
        {
            _offStyle = color;
            return this;
        }

        /// <summary>
        ///     Additional class
        /// </summary>
        /// <param name="customClass"></param>
        /// <returns></returns>
        public Toggle CustomClass(string customClass)
        {
            _customClass = customClass;
            return this;
        }

        /// <summary>
        ///     Width of toggle
        /// </summary>
        /// <param name="width"></param>
        /// <returns></returns>
        public Toggle Width(int width)
        {
            _width = width;
            return this;
        }

        /// <summary>
        ///     Height of toggle
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public Toggle Height(int height)
        {
            _height = height;
            return this;
        }
    }
}
