using System;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.IO;

namespace sidekick
{
    public class IconBuilder : IHtmlString
    {
        private Icon _icon;

        public IconBuilder(Icon icon)
        {
            _icon = icon;
        }

        private string DrawIcon()
        {
            using (HtmlTextWriter writer = new HtmlTextWriter(new StringWriter()))
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, _icon._primaryIcon);
                writer.RenderBeginTag(HtmlTextWriterTag.I);
                writer.RenderEndTag();

                return new MvcHtmlString(writer.InnerWriter.ToString()).ToString();
            }
        }

        private string DrawStackedIcon()
        {
            using (HtmlTextWriter writer = new HtmlTextWriter(new StringWriter()))
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "fa fa-stack fa-lg");
                writer.RenderBeginTag(HtmlTextWriterTag.Span); // span

                // being icons
                writer.AddAttribute(HtmlTextWriterAttribute.Class, String.Format("{0} fa-stack-2x", _icon._primaryIcon));
                writer.RenderBeginTag(HtmlTextWriterTag.I);
                writer.RenderEndTag();

                writer.AddAttribute(HtmlTextWriterAttribute.Class, String.Format("{0} fa-stack-1x", _icon._secondaryIcon));
                writer.RenderBeginTag(HtmlTextWriterTag.I);
                writer.RenderEndTag();
                // end icons

                writer.RenderEndTag(); // span

                return new MvcHtmlString(writer.InnerWriter.ToString()).ToString();
            }
        }

        private string DrawStackedText()
        {
            using (HtmlTextWriter writer = new HtmlTextWriter(new StringWriter()))
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "fa fa-stack fa-lg");
                writer.RenderBeginTag(HtmlTextWriterTag.Span); // span

                // being icons
                writer.AddAttribute(HtmlTextWriterAttribute.Class, String.Format("{0} fa-stack-2x", _icon._primaryIcon));
                writer.RenderBeginTag(HtmlTextWriterTag.I);
                writer.RenderEndTag();

                writer.AddAttribute(HtmlTextWriterAttribute.Class, "fa-stack-1x");
                writer.RenderBeginTag(HtmlTextWriterTag.Strong);
                writer.Write(_icon._secondaryText);
                writer.RenderEndTag();
                // end icons

                writer.RenderEndTag(); // span

                return new MvcHtmlString(writer.InnerWriter.ToString()).ToString();
            }
        }

        public string ToHtmlString()
        {
            if (_icon == null)
            {
                return String.Empty;
            }
            else if (_icon.IsSingle)
            {
                return DrawIcon();
            }
            else if (_icon.IsStackedIcon)
            {
                return DrawStackedIcon();
            }
            else if (_icon.IsStackedText)
            {
                return DrawStackedText();
            }
            else
            {
                return String.Empty;
            }
        }
    }
}
