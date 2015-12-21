namespace sidekick
{
    public class Panel
    {
        /// <summary>
        ///     Extra HTML class for the panel
        /// </summary>
        public virtual string Class { get; set; }

        /// <summary>
        ///     Color of the panel. Defaults to "default"
        /// </summary>
        public virtual Colors Color { get; set; }

        /// <summary>
        ///     Title heading size
        /// </summary>
        public virtual HeadingSize HeadingSize { get; set; }

        /// <summary>
        ///     Icon Css to be placed to the left of the header
        /// </summary>
        public virtual string Icon { get; set; }

        /// <summary>
        ///     Title of the panel
        /// </summary>
        public virtual string Title { get; set; }

        public Panel() 
        {
            Color = Colors.Default;
            HeadingSize = HeadingSize.H3;
        }
    }
}
