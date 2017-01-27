namespace sidekick
{
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

        public Toggle OnText(string text)
        {
            _onText = text;
            return this;
        }

        public Toggle OffText(string text)
        {
            _offText = text;
            return this;
        }

        public Toggle Size(ToggleSize size)
        {
            _size = size;
            return this;
        }

        public Toggle OnStyle(Colors color)
        {
            _onStyle = color;
            return this;
        }

        public Toggle OffStyle(Colors color)
        {
            _offStyle = color;
            return this;
        }

        public Toggle CustomClass(string customClass)
        {
            _customClass = customClass;
            return this;
        }

        public Toggle Width(int width)
        {
            _width = width;
            return this;
        }

        public Toggle Height(int height)
        {
            _height = height;
            return this;
        }
    }
}
