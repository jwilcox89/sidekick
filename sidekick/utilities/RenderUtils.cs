using System;
using System.Linq;

namespace sidekick
{
    /// <summary>
    ///     Render a document (Word, PDF, Excel etc) in or out of the web browser
    /// </summary>
    public class RenderUtils
    {
        /// <summary>
        ///     Get the content type based on the document name provided
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string GetContentType(string filename)
        {
            string extension = filename.GetFileExtention();
            foreach (FileType type in Enum.GetValues(typeof(FileType)).Cast<FileType>())
            {
                if (extension == type.GetAttribute<ExtensionAttribute>().Extension)
                    return type.GetAttribute<HtmlBuilderAttribute>().Tag;
            }

            return "application/octet-stream";
        }

        /// <summary>
        ///     Get the content type based on the document type provided
        /// </summary>
        /// <param name="fileType"></param>
        /// <returns></returns>
        public static string GetContentType(FileType fileType)
        {
            return fileType.GetAttribute<HtmlBuilderAttribute>().Tag;
        }
    }
}