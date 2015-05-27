namespace sidekick
{
    public class Tab
    {
        /// <summary>
        ///     True if the tab is active. Defaults as false
        /// </summary>
        public virtual bool Active { get; set; }

        /// <summary>
        ///     HTML name of the tab
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        ///     Icon for the tab
        /// </summary>
        public virtual string Icon { get; set; }
    }
}
