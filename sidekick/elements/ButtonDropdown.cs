namespace sidekick
{
    public class ButtonDropdown
    {
        internal string _title;
        internal Icon _icon;
        internal Colors _color;
        
        /// <summary>
        ///     Defaults:
        ///     <para>Color: Default</para>
        /// </summary>
        public ButtonDropdown()
        {
            _color = Colors.Default;
        }

        public ButtonDropdown(Colors color)
        {
            _color = color;
        }

        /// <summary>
        ///     Set the title of the button
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public ButtonDropdown Title(string title)
        {
            _title = title;
            return this;
        }

        /// <summary>
        ///     Set the title of the button
        /// </summary>
        /// <param name="title"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public ButtonDropdown Title(string title, string icon)
        {
            _title = title;
            _icon = new Icon(icon);
            return this;
        }

        /// <summary>
        ///     Set the title of the button
        /// </summary>
        /// <param name="title"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public ButtonDropdown Title(string title, Icon icon)
        {
            _title = title;
            _icon = icon;
            return this;
        }
    }
}
