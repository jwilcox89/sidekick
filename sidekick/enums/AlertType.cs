namespace sidekick
{
    /// <summary>
    ///     Alert box style options. HtmlBuilder attribute: Class = html class, Icon = font awesome icon
    /// </summary>
    public enum AlertType
    {
        [HtmlBuilder(Class = "success", Icon = "fa fa-check")]
        Success,

        [HtmlBuilder(Class = "danger", Icon = "fa fa-fire")]
        Danger,

        [HtmlBuilder(Class = "warning", Icon = "fa fa-exclamation-triangle")]
        Warning,

        [HtmlBuilder(Class = "info", Icon = "fa fa-info-circle")]
        Info
    }
}
