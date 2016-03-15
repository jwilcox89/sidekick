namespace sidekick
{
    /// <summary>
    ///     Sizes for input groups
    /// </summary>
    public enum InputGroupSize
    {
        [HtmlBuilder(Class = "")]
        Regular,

        [HtmlBuilder(Class = "input-group-sm")]
        Small,

        [HtmlBuilder(Class = "input-group-lg")]
        Large
    }
}
