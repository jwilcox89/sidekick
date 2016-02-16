namespace sidekick
{
    /// <summary>
    ///     Heading tags. HtmlBuilder attribute: Tag = html tag value
    /// </summary>
    public enum HeadingSize
    {
        [HtmlBuilder(Tag = "h1")]
        H1,

        [HtmlBuilder(Tag = "h2")]
        H2,

        [HtmlBuilder(Tag = "h3")]
        H3,

        [HtmlBuilder(Tag = "h4")]
        H4,

        [HtmlBuilder(Tag = "h5")]
        H5
    }
}
