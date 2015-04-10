using System.ComponentModel.DataAnnotations;

namespace sidekick
{
    /// <summary>
    ///     Months in the year
    /// </summary>
    public enum Months
    {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }

    /// <summary>
    ///     File types
    /// </summary>
    public enum FileType
    {
        PDF,
        Excel,
        Csv,
        Word,
        Other
    }

    /// <summary>
    ///     Alert box style options
    /// </summary>
    public enum AlertType
    {
        [HtmlBuilder(Class="alert alert-success", Icon="fa fa-check")]
        Success,

        [HtmlBuilder(Class="alert alert-danger", Icon="fa fa-fire")]
        Danger,

        [HtmlBuilder(Class="alert alert-warning", Icon="fa fa-exclamation-triangle")]
        Warning,

        [HtmlBuilder(Class="alert alert-info", Icon="fa fa-info")]
        Info
    }

    /// <summary>
    ///     Button color options
    /// </summary>
    public enum ButtonColor
    {
        [HtmlBuilder(Class="btn btn-success")]
        Success,

        [HtmlBuilder(Class="btn btn-danger")]
        Danger,

        [HtmlBuilder(Class="btn btn-primary")]
        Primary,

        [HtmlBuilder(Class="btn btn-warning")]
        Warning,

        [HtmlBuilder(Class="btn btn-info")]
        Info,

        [HtmlBuilder(Class="btn btn-default")]
        Default
    }

    public enum ModalSize
    {
        [HtmlBuilder(Class="")]
        Regular,

        [HtmlBuilder(Class="modal-sm")]
        Small,

        [HtmlBuilder(Class="modal-lg")]
        Large
    }

    public enum HeadingSize
    {
        [HtmlBuilder(Tag="h1")]
        H1,
        
        [HtmlBuilder(Tag="h2")]
        H2,

        [HtmlBuilder(Tag="h3")]
        H3,

        [HtmlBuilder(Tag="h4")]
        H4,

        [HtmlBuilder(Tag="h5")]
        H5
    }

    public enum PanelColor
    {
        [HtmlBuilder(Class="default")]
        Default,

        [HtmlBuilder(Class="primary")]
        Primary,
        
        [HtmlBuilder(Class="success")]
        Success,

        [HtmlBuilder(Class="info")]
        Info,

        [HtmlBuilder(Class="warning")]
        Warning,

        [HtmlBuilder(Class="danger")]
        Danger
    }
}
