namespace sidekick
{
    public class Panel : IPanel
    {
        /// <summary>
        ///     Extra HTML class for the panel
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        ///     Color of the panel. Defaults to "default"
        /// </summary>
        public Colors Color { get; set; }

        /// <summary>
        ///     Title heading size
        /// </summary>
        public HeadingSize HeadingSize { get; set; }

        /// <summary>
        ///     Icon Css to be placed to the left of the header
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        ///     Title of the panel
        /// </summary>
        public string Title { get; set; }

        public Panel() {
            Color = Colors.Default;
            HeadingSize = HeadingSize.H3;
        }
    }
}
