namespace sidekick
{
    public class Step
    {
        internal string Title { get; set; }
        internal Icon Icon { get; set; }
        internal string Description { get; set; }
        internal bool Complete { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title">Title of the step</param>
        /// <param name="icon">Icon associated with the step</param>
        /// <param name="description">Content forthe popover</param>
        public Step(string title, Icon icon, string description)
        {
            Title = title;
            Icon = icon;
            Description = description;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title">Title of the step</param>
        /// <param name="icon">Icon associated with the step</param>
        /// <param name="description">Content forthe popover</param>
        /// <param name="complete">True if the step is complete</param>
        public Step(string title, Icon icon, string description, bool complete)
        {
            Title = title;
            Icon = icon;
            Description = description;
            Complete = complete;
        }
    }
}
