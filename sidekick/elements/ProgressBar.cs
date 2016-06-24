using System;

namespace sidekick
{
    public class ProgressBar
    {
        internal int _currentValue;
        internal string _label;
        internal Colors _color;
        internal bool _striped;
        internal bool _animated;

        internal string _contextualClass => _color != Colors.Default ? String.Format("progress-bar-{0}", _color.GetAttribute<HtmlBuilderAttribute>().Class) : String.Empty;
        internal string _stripedClass => _striped ? "progress-bar-striped" : String.Empty;
        internal string _animatedClass => _animated ? "active" : String.Empty;

        public ProgressBar(int currentValue)
        {
            _color = Colors.Default;
            _currentValue = currentValue;
        }

        public ProgressBar(int currentValue, Colors color)
        {
            _color = color;
            _currentValue = currentValue;
        }

        public ProgressBar Label(string label)
        {
            _label = label;
            return this;
        }

        public ProgressBar Striped()
        {
            _striped = true;
            return this;
        }

        public ProgressBar Animated()
        {
            _animated = true;
            return this;
        }
    }
}
