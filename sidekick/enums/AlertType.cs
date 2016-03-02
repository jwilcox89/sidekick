namespace sidekick
{
    /// <summary>
    ///     Alert box style options. HtmlBuilder attribute: Class = html class, Icon = font awesome icon
    /// </summary>
    public enum AlertType
    {
        [HtmlBuilder(Class = "alert-success", Icon = "fa fa-check")]
        Success,

        [HtmlBuilder(Class = "alert-danger", Icon = "fa fa-fire")]
        Danger,

        [HtmlBuilder(Class = "alert-warning", Icon = "fa fa-exclamation-triangle")]
        Warning,

        [HtmlBuilder(Class = "alert-info", Icon = "fa fa-info-circle")]
        Info
    }
}
