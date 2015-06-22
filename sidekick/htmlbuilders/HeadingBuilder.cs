using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.UI;
using System.IO;
using System.Collections.Generic;

namespace sidekick
{
    public class HeadingBuilder
    {
        public static MvcHtmlString Build(HeadingSize size, string text, string subtext = null, Colors color = Colors.Default) {
            using (HtmlTextWriter writer = new HtmlTextWriter(new StringWriter())) {
                writer.Write(string.Format("<{0}>", size.GetHtmlAttributes<HeadingSize>().Tag));
                writer.Write(text);
                if (!string.IsNullOrEmpty(subtext)) {
                    writer.Write(string.Format(" <span class='label label-{0}'>{1}</span>", color.GetHtmlAttributes<Colors>().Class, subtext));
                }
                writer.Write(string.Format("</{0}>", size.GetHtmlAttributes<HeadingSize>().Tag));

                return new MvcHtmlString(writer.InnerWriter.ToString());
            }
        }
    }
}
