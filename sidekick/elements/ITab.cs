namespace sidekick
{
    public interface ITab
    {
        /// <summary>
        ///     True if the tab is active. Defaults as false
        /// </summary>
        bool Active { get; set; }

        /// <summary>
        ///     HTML name of the tab
        /// </summary>
        string Name { get; set; }
    }
}
