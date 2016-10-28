namespace sidekick
{
    /// <summary>
    ///     Bootstrap 'Panel' element
    /// </summary>
    public class Panel
    {
        internal string _id;
        internal string _class;
        internal Colors _color;
        internal HeadingSize _headingSize;
        internal Icon _icon;
        internal string _title;

        /// <summary>
        ///     DEFAULTS:
        ///     <para>Color = Default</para>
        ///     <para>HeadingSize = H3</para>
        /// </summary>
        public Panel()
        {
            _color = Colors.Default;
            _headingSize = HeadingSize.H3;
        }

        /// <summary>
        ///     DEFAULTS:
        ///     <para>HeadingSize = H3</para>
        /// </summary>
        /// <param name="color"></param>
        public Panel(Colors color)
        {
            _color = color;
            _headingSize = HeadingSize.H3;
        }

        /// <summary>
        ///     DEFAULTS:
        ///     <para>Color = Default</para>
        ///     <para>HeadingSize = H3</para>
        /// </summary>
        /// <param name="panelID">HTML ID for the panel</param>
        public Panel(string panelID)
        {
            _id = panelID;
            _color = Colors.Default;
            _headingSize = HeadingSize.H3;
        }

        /// <summary>
        ///     DEFAULTS:
        ///     <para>HeadingSize: H3</para>
        /// </summary>
        /// <param name="panelID"></param>
        /// <param name="color"></param>
        public Panel(string panelID, Colors color)
        {
            _id = panelID;
            _color = color;
            _headingSize = HeadingSize.H3;
        }

        /// <summary>
        ///     Set the class for the panel
        /// </summary>
        /// <param name="class"></param>
        /// <returns></returns>
        public Panel Class(string @class)
        {
            _class = @class;
            return this;
        }

        /// <summary>
        ///     Set the title for the panel
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public Panel Title(string title)
        {
            _title = title;
            return this;
        }

        /// <summary>
        ///     Set the title for the panel with an icon
        /// </summary>
        /// <param name="title"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public Panel Title(string title, Icon icon)
        {
            _title = title;
            _icon = icon;
            return this;
        }

        /// <summary>
        ///     Set the title for the panel with an icon
        /// </summary>
        /// <param name="title"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public Panel Title(string title, string icon)
        {
            _title = title;
            _icon = new Icon(icon);
            return this;
        }

        /// <summary>
        ///     Set the title for the panel with an icon and custom heading size
        /// </summary>
        /// <param name="title"></param>
        /// <param name="icon"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public Panel Title(string title, Icon icon, HeadingSize size)
        {
            _title = title;
            _icon = icon;
            _headingSize = size;
            return this;
        }

        /// <summary>
        ///     Set the title for the panel with an icon and custom heading size
        /// </summary>
        /// <param name="title"></param>
        /// <param name="icon"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public Panel Title(string title, string icon, HeadingSize size)
        {
            _title = title;
            _icon = new Icon(icon);
            _headingSize = size;
            return this;
        }
    }
}
