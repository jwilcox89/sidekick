namespace sidekick
{
    /// <summary>
    ///     Modal sizes. HtmlBuilder attribute: Class = modal size class
    /// </summary>
    public enum ModalSize
    {
        [HtmlBuilder(Class = "")]
        Regular,

        [HtmlBuilder(Class = "modal-sm")]
        Small,

        [HtmlBuilder(Class = "modal-lg")]
        Large
    }
}
