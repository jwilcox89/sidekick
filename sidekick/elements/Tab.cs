namespace sidekick
{
    public class Tab : ITab
    {
        /// <summary>
        ///     True if the tab is active. Defaults as false
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        ///     HTML name of the tab
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Icon for the tab
        /// </summary>
        public string Icon { get; set; }
    }
}
