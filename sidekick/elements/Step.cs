namespace sidekick
{
    public class Step : IStep
    {
        /// <summary>
        ///     Title of the step
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Content for the popover
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     True if the step is complete
        /// </summary>
        public bool Complete { get; set; }
    }
}
