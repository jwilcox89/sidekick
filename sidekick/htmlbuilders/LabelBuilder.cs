using System;
using System.Web.Mvc;
using System.Web.UI;
using System.IO;

namespace sidekick
{
    public static class LabelBuilder
    {
        public static MvcHtmlString Build(Colors color, string text) {
            using (HtmlTextWriter writer = new HtmlTextWriter(new StringWriter())) {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, string.Format("label label-{0}", color.GetHtmlAttributes<Colors>().Class));
                writer.RenderBeginTag(HtmlTextWriterTag.Span);
                writer.Write(text);
                writer.RenderEndTag();

                return new MvcHtmlString(writer.InnerWriter.ToString());
            }
        }
    }
}
