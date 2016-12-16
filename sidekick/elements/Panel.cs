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

        /// <summary>
        ///     DEFAULTS:
        ///     <para>Color = Default</para>
        ///     <para>HeadingSize = H3</para>
        /// </summary>
        public Panel()
        {
            _color = Colors.Default;
        }

        /// <summary>
        ///     DEFAULTS:
        ///     <para>HeadingSize = H3</para>
        /// </summary>
        /// <param name="color"></param>
        public Panel(Colors color)
        {
            _color = color;
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
    }
}
