namespace sidekick
{
    /// <summary>
    ///     Bootstrap Switch sizes (http://www.bootstrap-switch.org/).
    /// </summary>
    public enum SwitchSize
    {
        [HtmlBuilder(Class = "mini")]
        Mini,

        [HtmlBuilder(Class = "small")]
        Small,

        [HtmlBuilder(Class = "normal")]
        Normal,

        [HtmlBuilder(Class = "large")]
        Large
    }
}
