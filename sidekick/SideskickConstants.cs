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
    ///     Sizes for input groups
    /// </summary>
    public enum InputGroupSize
    {
        [HtmlBuilder(Class="input-group-lg")]
        Large,

        [HtmlBuilder(Class="")]
        Regular,

        [HtmlBuilder(Class="input-group-sm")]
        Small
    }

    /// <summary>
    ///     File types. HtmlBuilder attribute: Tag = ContentType
    /// </summary>
    public enum FileType
    {
        [HtmlBuilder(Class="fa fa-file-pdf-o", Tag="application/pdf")]
        PDF,

        [HtmlBuilder(Class="fa fa-file-excel-o", Tag="application/x-msexcel")]
        Excel,

        [HtmlBuilder(Class="fa fa-file-excel-o", Tag="application/x-csv")]
        Csv,

        [HtmlBuilder(Class="fa fa-file-word-o", Tag="application/msword")]
        Word,

        [HtmlBuilder(Class="fa fa-file-o", Tag="application/octet-stream")]
        Other
    }

    /// <summary>
    ///     Bootstrap color options. HtmlBuilder attribute: Class = bootstrap color css
    /// </summary>
    public enum Colors
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

    /// <summary>
    ///     Alert box style options. HtmlBuilder attribute: Class = html class, Icon = font awesome icon
    /// </summary>
    public enum AlertType
    {
        [HtmlBuilder(Class="success", Icon="fa fa-check")]
        Success,

        [HtmlBuilder(Class="danger", Icon="fa fa-fire")]
        Danger,

        [HtmlBuilder(Class="warning", Icon="fa fa-exclamation-triangle")]
        Warning,

        [HtmlBuilder(Class="info", Icon="fa fa-info")]
        Info
    }

    /// <summary>
    ///     Modal sizes. HtmlBuilder attribute: Class = modal size class
    /// </summary>
    public enum ModalSize
    {
        [HtmlBuilder(Class="")]
        Regular,

        [HtmlBuilder(Class="modal-sm")]
        Small,

        [HtmlBuilder(Class="modal-lg")]
        Large
    }

    /// <summary>
    ///     Heading tags. HtmlBuilder attribute: Tag = html tag value
    /// </summary>
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
}
