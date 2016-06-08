namespace sidekick
{
    /// <summary>
    ///     File types. HtmlBuilder attribute: Tag = ContentType
    /// </summary>
    public enum FileType
    {
        [HtmlBuilder(Class = "fa fa-file-pdf-o", Tag = "application/pdf")]
        [Extension(".pdf")]
        PDF,

        [HtmlBuilder(Class = "fa fa-file-excel-o", Tag = "application/x-msexcel")]
        [Extension(".xls")]
        Excel,

        [HtmlBuilder(Class = "fa fa-file-excel-o", Tag = "application/x-csv")]
        [Extension(".csv")]
        Csv,

        [HtmlBuilder(Class = "fa fa-file-word-o", Tag = "application/msword")]
        [Extension(".doc")]
        Doc,

        [HtmlBuilder(Class = "fa fa-file-word-o", Tag = "application/vnd.openxmlformats-officedocument.wordprocessingml.document")]
        [Extension(".docx")]
        Docx,

        [HtmlBuilder(Class = "fa fa-file-o", Tag = "application/octet-stream")]
        Other
    }
}
