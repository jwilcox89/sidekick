using System;
using System.Web.Mvc;
using System.Web.UI;
using System.IO;

namespace sidekick
{
    /// <summary>
    ///     HTML builder for a heading element element.
    /// </summary>
    public static class HeadingBuilder
    {
        public static MvcHtmlString BuildHeading(this HtmlHelper helper, HeadingSize size, string text)
        {
            return BuildHeading(helper, size, text, null, Colors.Default);
        }

        public static MvcHtmlString BuildHeading(this HtmlHelper helper, HeadingSize size, string text, string subtext)
        {
            return BuildHeading(helper, size, text, subtext, Colors.Default);
        }

        public static MvcHtmlString BuildHeading(this HtmlHelper helper, HeadingSize size, string text, string subtext, Colors color)
        {
            using (HtmlTextWriter writer = new HtmlTextWriter(new StringWriter()))
            {
                writer.Write(String.Format("<{0}>", size.GetAttribute<HeadingSize, HtmlBuilderAttribute>().Tag));
                writer.Write(text);
                if (!String.IsNullOrEmpty(subtext))
                    writer.Write(String.Format(" <span class='label label-{0}'>{1}</span>", color.GetAttribute<Colors, HtmlBuilderAttribute>().Class, subtext));

                writer.Write(String.Format("</{0}>", size.GetAttribute<HeadingSize, HtmlBuilderAttribute>().Tag));

                return new MvcHtmlString(writer.InnerWriter.ToString());
            }
        }
    }
}
