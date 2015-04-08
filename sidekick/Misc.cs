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
        [Display(Name="alert alert-success", Description="fa fa-check")]
        Success,

        [Display(Name="alert alert-danger", Description="fa fa-fire")]
        Danger,

        [Display(Name="alert alert-warning", Description="fa fa-exclamation-triangle")]
        Warning,

        [Display(Name="alert alert-info", Description="fa fa-info")]
        Info
    }

    /// <summary>
    ///     Button color options
    /// </summary>
    public enum ButtonColor
    {
        [Display(Name="btn btn-success")]
        Success,

        [Display(Name="btn btn-danger")]
        Danger,

        [Display(Name="btn btn-primary")]
        Primary,

        [Display(Name="btn btn-warning")]
        Warning,

        [Display(Name="btn btn-info")]
        Info,

        [Display(Name="btn btn-default")]
        Default
    }

    public enum ModalSize
    {
        Regular,
        Small,
        Large
    }
}
