namespace sidekick
{
    public class Step
    {
        /// <summary>
        ///     Title of the step
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        ///     Icon associated with the step
        /// </summary>
        public virtual string Icon { get; set; }

        /// <summary>
        ///     Content for the popover
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        ///     True if the step is complete
        /// </summary>
        public virtual bool Complete { get; set; }
    }
}
