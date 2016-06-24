namespace sidekick
{
    public class Button
    {
        internal string _title;
        internal Icon _icon;
        internal Colors _color;
        
        /// <summary>
        ///     Defaults:
        ///     <para>Color: Default</para>
        /// </summary>
        public Button()
        {
            _color = Colors.Default;
        }

        public Button(Colors color)
        {
            _color = color;
        }

        /// <summary>
        ///     Set the title of the button
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public Button Title(string title)
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
        public Button Title(string title, string icon)
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
        public Button Title(string title, Icon icon)
        {
            _title = title;
            _icon = icon;
            return this;
        }
    }
}
