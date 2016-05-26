using System;

namespace sidekick
{
    /// <summary>
    ///     Builds an icon objects.
    ///     Stacked font-awesome icons supported.
    /// </summary>
    public class Icon
    {
        internal string _primaryIcon;
        internal string _secondaryIcon;
        internal string _secondaryText;

        internal bool IsSingle => String.IsNullOrEmpty(_secondaryIcon) && String.IsNullOrEmpty(_secondaryText);
        internal bool IsStackedIcon => String.IsNullOrEmpty(_secondaryText) && !String.IsNullOrEmpty(_secondaryIcon);
        internal bool IsStackedText => !String.IsNullOrEmpty(_secondaryText) && String.IsNullOrEmpty(_secondaryIcon);

        /// <summary>
        ///     Build a single icon
        /// </summary>
        /// <param name="icon"></param>
        public Icon(string icon)
        {
            _primaryIcon = icon;
        }

        /// <summary>
        ///     Build a stack of two icons
        /// </summary>
        /// <param name="outterIcon">The outter icon (ex. a square)</param>
        /// <param name="innerIcon">The inner icon (ex. a question mark)</param>
        /// <returns></returns>
        public Icon Stacked(string innerIcon)
        {
            _secondaryIcon = innerIcon;
            return this;
        }

        /// <summary>
        ///     Build a stack of one icon and text
        /// </summary>
        /// <param name="outterIcon">The outter icon (ex. a square)</param>
        /// <param name="innerText">The inner text (ex. "1")</param>
        /// <returns></returns>
        public Icon StackedText(string innerText)
        {
            _secondaryText = innerText;
            return this;
        }
    }
}
