namespace sidekick
{
    /// <summary>
    ///     Bootstrap Accordion element
    /// </summary>
    public class Accordion
    {
        internal string _parentID;

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
        public Accordion(string parentID)
        {
            _parentID = parentID;
        }
    }
}
