namespace sidekick
{
    public enum TabTypes
    {
        [HtmlBuilder(Class = "nav-tabs")]
        Regular,

        [HtmlBuilder(Class = "nav-pills")]
        Pills
    }
}
