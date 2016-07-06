using System;

namespace sidekick
{
    /// <summary>
    ///     Bootstrap 'Progress Bar' element
    /// </summary>
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

        /// <summary>
        ///     DEFAULTS:
        ///     <para>Color: Default</para>
        /// </summary>
        /// <param name="currentValue"></param>
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

        /// <summary>
        ///     Set the label
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        public ProgressBar Label(string label)
        {
            _label = label;
            return this;
        }

        /// <summary>
        ///     Toggles the striped feature on
        /// </summary>
        /// <returns></returns>
        public ProgressBar Striped()
        {
            _striped = true;
            return this;
        }

        /// <summary>
        ///     Animates the progress bar
        /// </summary>
        /// <returns></returns>
        public ProgressBar Animated()
        {
            _animated = true;
            return this;
        }
    }
}
