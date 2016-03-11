namespace sidekick
{
    public class Panel
    {
        /// <summary>
        ///     Extra HTML class for the panel
        /// </summary>
        internal string _class;

        /// <summary>
        ///     Color of the panel. Defaults to "default"
        /// </summary>
        internal Colors _color;

        /// <summary>
        ///     Title heading size
        /// </summary>
        internal HeadingSize _headingSize;

        /// <summary>
        ///     Icon Css to be placed to the left of the header
        /// </summary>
        internal string _icon;

        /// <summary>
        ///     Title of the panel
        /// </summary>
        internal string _title;

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

        public Panel() 
        {
            _color = Colors.Default;
            _headingSize = HeadingSize.H3;
        }
    }
}
