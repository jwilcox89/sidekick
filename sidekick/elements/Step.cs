﻿namespace sidekick
{
    public class Step
    {
        /// <summary>
        ///     Title of the step
        /// </summary>
        internal string Title { get; set; }

        /// <summary>
        ///     Icon associated with the step
        /// </summary>
        internal string Icon { get; set; }

        /// <summary>
        ///     Content for the popover
        /// </summary>
        internal string Description { get; set; }

        /// <summary>
        ///     True if the step is complete
        /// </summary>
        internal bool Complete { get; set; }

        public Step(string title, string icon, string description, bool complete = false)
        {
            Title = title;
            Icon = icon;
            Description = description;
            Complete = complete;
        }
    }
}
