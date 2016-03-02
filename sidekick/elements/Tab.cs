namespace sidekick
{
    public class Tab
    {
        /// <summary>
        ///     Text that will be displayed on the tab
        /// </summary>
        internal string DisplayText { get; set; }

        /// <summary>
        ///     True if the tab is active. Defaults as false
        /// </summary>
        internal virtual bool Active { get; set; }

        /// <summary>
        ///     HTML name of the tab
        /// </summary>
        internal virtual string Name { get; set; }

        /// <summary>
        ///     Icon for the tab
        /// </summary>
        internal virtual string Icon { get; set; }

        public Tab(string displayText, string icon, string name, bool active = false)
        {
            DisplayText = displayText;
            Icon = icon;
            Name = name;
            Active = active;
        }
    }
}
