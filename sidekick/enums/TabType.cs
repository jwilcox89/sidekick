namespace sidekick
{
    /// <summary>
    ///     Bootstrap 'Tab' element types.
    /// </summary>
    public enum TabType
    {
        [HtmlBuilder(Class = "nav-tabs")]
        Tabs,

        [HtmlBuilder(Class = "nav-pills")]
        Pills
    }
}
