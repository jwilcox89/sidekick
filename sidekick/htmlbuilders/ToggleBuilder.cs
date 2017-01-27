using System;
using System.Web;
using System.Web.UI;
using System.Web.Mvc;
using System.IO;

namespace sidekick
{
    public class ToggleBuilder : Toggle, IHtmlString
    {
        private string _elementName;
        private bool _toggleState;

        public ToggleBuilder(string elementName, bool toggleState)
        {
            _elementName = elementName;
            _toggleState = toggleState;
        }

        public string ToHtmlString()
        {
            using (HtmlTextWriter writer = new HtmlTextWriter(new StringWriter()))
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Name, _elementName);
                writer.AddAttribute(HtmlTextWriterAttribute.Type, "checkbox");
                writer.AddAttribute("data-toggle", "toggle");

                if (_toggleState)
                    writer.AddAttribute(HtmlTextWriterAttribute.Checked, "");

                if (!String.IsNullOrEmpty(_onText))
                    writer.AddAttribute("data-on", _onText);

                if (!String.IsNullOrEmpty(_offText))
                    writer.AddAttribute("data-off", _offText);

                if (_size.HasValue)
                    writer.AddAttribute("data-size", _size.Value.GetAttribute<HtmlBuilderAttribute>().Class);

                if (_onStyle.HasValue)
                    writer.AddAttribute("data-onstyle", _onStyle.Value.GetAttribute<HtmlBuilderAttribute>().Class);

                if (_offStyle.HasValue)
                    writer.AddAttribute("data-offstyle", _offStyle.Value.GetAttribute<HtmlBuilderAttribute>().Class);

                if (!String.IsNullOrEmpty(_customClass))
                    writer.AddAttribute("data-style", _customClass);

                if (_width.HasValue)
                    writer.AddAttribute("data-width", _width.Value.ToString());

                if (_height.HasValue)
                    writer.AddAttribute("data-height", _height.Value.ToString());

                writer.RenderBeginTag(HtmlTextWriterTag.Input);
                writer.RenderEndTag();

                return new MvcHtmlString(writer.InnerWriter.ToString()).ToString();
            }
        }
    }
}
