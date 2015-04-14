namespace sidekick
{
    public interface IStep
    {
        /// <summary>
        ///     Title of the step
        /// </summary>
        string Title { get; set; }

        /// <summary>
        ///     Icon associated with the step
        /// </summary>
        string Icon { get; set; }

        /// <summary>
        ///     Content for the popover
        /// </summary>
        string Description { get; set; }

        /// <summary>
        ///     True if the step is complete
        /// </summary>
        bool Complete { get; set; }
    }
}
