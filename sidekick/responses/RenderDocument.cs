using System.Web;

namespace sidekick
{
    /// <summary>
    ///     Render a document (Word, PDF, Excel etc) in or out of the web browser
    /// </summary>
    public class RenderDocument
    {
        /// <summary>
        ///     Render a document byte array.
        /// </summary>
        /// <param name="fileData"></param>
        /// <param name="fileName">Must end with file extension (ex .pdf)</param>
        /// <param name="displayInBrowser"></param>
        public static void Render(byte[] fileData, string fileName, bool displayInBrowser)
        {
            HttpResponse response = HttpContext.Current.Response;

            response.Clear();
            response.ClearHeaders();
            response.Buffer = true;
            response.AddHeader("Content-Length", fileData.Length.ToString());
            response.AddHeader("Expires", "0");
            response.AddHeader("Pragma", "cache");
            response.AddHeader("Cache-Control", "private");

            if (fileName.EndsWith(".pdf"))
            {
                response.ContentType = "application/pdf";
            }
            else if (fileName.EndsWith(".xls"))
            {
                response.ContentType = "application/x-msexcel";
            }
            else if (fileName.EndsWith(".csv"))
            {
                response.ContentType = "application/x-csv";
            }
            else
            {
                response.ContentType = "application/octet-stream";
            }

            string contentDisposition = "attachment";

            if (displayInBrowser)
                contentDisposition = "inline";

            //this causes it to download as a file - comment out or change "attachment" to "inline" to open in Adobe Reader
            response.AddHeader("Content-Disposition", "" + contentDisposition + "; filename=" + fileName);

            //Output the file
            response.BinaryWrite(fileData);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        /// <summary>
        ///     Render a document byte array.
        /// </summary>
        /// <param name="fileData"></param>
        /// <param name="fileName"></param>
        /// <param name="displayInBrowser"></param>
        public static void Render(byte[] fileData, FileType fileType, string fileName, bool displayInBrowser)
        {
            HttpResponse response = HttpContext.Current.Response;

            response.Clear();
            response.ClearHeaders();
            response.Buffer = true;
            response.AddHeader("Content-Length", fileData.Length.ToString());
            response.AddHeader("Expires", "0");
            response.AddHeader("Pragma", "cache");
            response.AddHeader("Cache-Control", "private");
            response.ContentType = fileType.GetAttribute<FileType, HtmlBuilderAttribute>().Tag;

            string contentDisposition = "attachment";

            if (displayInBrowser)
                contentDisposition = "inline";

            //this causes it to download as a file - comment out or change "attachment" to "inline" to open in Adobe Reader
            response.AddHeader("Content-Disposition", "" + contentDisposition + "; filename=" + fileName);

            //Output the file
            response.BinaryWrite(fileData);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }
}