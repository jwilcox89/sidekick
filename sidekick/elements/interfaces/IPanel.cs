namespace sidekick
{
    public interface IPanel
    {
        /// <summary>
        ///     Extra HTML class for the panel
        /// </summary>
        string Class { get; set; }

        /// <summary>
        ///     Color of the panel. Defaults to "default"
        /// </summary>
        Colors Color { get; set; }

        /// <summary>
        ///     Title heading size
        /// </summary>
        HeadingSize HeadingSize { get; set; }

        /// <summary>
        ///     Icon Css to be placed to the left of the header
        /// </summary>
        string Icon { get; set; }

        /// <summary>
        ///     Title of the panel
        /// </summary>
        string Title { get; set; }
    }
}
