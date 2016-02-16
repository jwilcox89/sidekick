namespace sidekick
{
    /// <summary>
    ///     Bootstrap color options. HtmlBuilder attribute: Class = bootstrap color css
    /// </summary>
    public enum Colors
    {
        [HtmlBuilder(Class = "default")]
        Default,

        [HtmlBuilder(Class = "primary")]
        Primary,

        [HtmlBuilder(Class = "success")]
        Success,

        [HtmlBuilder(Class = "info")]
        Info,

        [HtmlBuilder(Class = "warning")]
        Warning,

        [HtmlBuilder(Class = "danger")]
        Danger
    }
}
