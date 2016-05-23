namespace sidekick
{
    /// <summary>
    ///     Bootstrap 'Tab' element
    /// </summary>
    public class Tab
    {
        internal string DisplayText { get; set; }
        internal virtual bool Active { get; set; }
        internal virtual string Name { get; set; }
        internal virtual string Icon { get; set; }

        /// <summary>
        ///     Tab is not active
        /// </summary>
        /// <param name="displayText">Text that will display on the tab</param>
        /// <param name="icon">Icon to be used in the tab heading</param>
        /// <param name="name">HTML name for the element</param>
        public Tab(string displayText, string icon, string name)
        {
            DisplayText = displayText;
            Icon = icon;
            Name = name;
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="displayText">Text that will display on the tab</param>
        /// <param name="icon">Icon to be used in the tab heading</param>
        /// <param name="name">HTML name for the element</param>
        /// <param name="active">True if the tab is the active tab</param>
        public Tab(string displayText, string icon, string name, bool active)
        {
            DisplayText = displayText;
            Icon = icon;
            Name = name;
            Active = active;
        }
    }
}
