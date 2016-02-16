namespace sidekick
{
    /// <summary>
    ///     File types. HtmlBuilder attribute: Tag = ContentType
    /// </summary>
    public enum FileType
    {
        [HtmlBuilder(Class = "fa fa-file-pdf-o", Tag = "application/pdf")]
        PDF,

        [HtmlBuilder(Class = "fa fa-file-excel-o", Tag = "application/x-msexcel")]
        Excel,

        [HtmlBuilder(Class = "fa fa-file-excel-o", Tag = "application/x-csv")]
        Csv,

        [HtmlBuilder(Class = "fa fa-file-word-o", Tag = "application/msword")]
        Doc,

        [HtmlBuilder(Class = "fa fa-file-word-o", Tag = "application/vnd.openxmlformats-officedocument.wordprocessingml.document")]
        Docx,

        [HtmlBuilder(Class = "fa fa-file-o", Tag = "application/octet-stream")]
        Other
    }
}
