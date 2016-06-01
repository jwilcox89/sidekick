namespace sidekick
{
    /// <summary>
    ///     Bootstrap Accordion element
    /// </summary>
    public class Accordion
    {
        internal string _parentID;
        internal Icon _icon;

        /// <summary>
        ///     Use this overload if you want more than one panel to open at one time.
        /// </summary>
        public Accordion()
        {
        }

        /// <summary>
        ///     Use this overload if you want only one panel to open at a time.
        /// </summary>
        /// <param name="parentID"></param>
        /// <param name="icon"></param>
        public Accordion(string parentID, Icon icon)
        {
            _parentID = parentID;
            _icon = icon;
        }

        /// <summary>
        ///     Use this overload if you want only one panel to open at a time.
        /// </summary>
        /// <param name="parentID"></param>
        /// <param name="icon"></param>
        public Accordion(string parentID, string icon)
        {
            _parentID = parentID;
            _icon = new Icon(icon);
        }
    }
}
