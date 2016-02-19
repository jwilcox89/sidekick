using System;
using System.Web.Mvc;
using System.Web.UI;
using System.IO;

namespace sidekick
{
    public static class HeadingBuilder
    {
        public static MvcHtmlString BuildHeading(this HtmlHelper helper, HeadingSize size, string text, string subtext = null, Colors color = Colors.Default)
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
