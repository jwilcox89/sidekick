namespace sidekick
{
    public class Panel
    {
        internal string _class;
        internal Colors _color;
        internal HeadingSize _headingSize;
        internal string _icon;
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
        ///     Set the color of the panel
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public Panel Color(Colors color)
        {
            _color = color;
            return this;
        }

        /// <summary>
        ///     Set the heading size for the panel
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public Panel Heading(HeadingSize size)
        {
            _headingSize = size;
            return this;
        }

        /// <summary>
        ///     Set the icon for the panel
        /// </summary>
        /// <param name="icon"></param>
        /// <returns></returns>
        public Panel Icon(string icon)
        {
            _icon = icon;
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
    }
}
