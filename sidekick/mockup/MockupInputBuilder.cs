using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.Mvc;
using System.IO;

namespace sidekick.mockup
{
    public enum MockupInputType
    {
        Textbox,
        Selectlist
    }

    public class MockupInputBuilder : IHtmlString
    {
        IList<string> _options = new List<string>();
        string _label;
        MockupInputType _inputType;

        public MockupInputBuilder(HtmlHelper helper, string label, MockupInputType inputType)
        {
            _label = label;
            _inputType = inputType;
        }

        public MockupInputBuilder AddOption(string option)
        {
            _options.Add(option);
            return this;
        }

        public string ToHtmlString()
        {
            using (HtmlTextWriter writer = new HtmlTextWriter(new StringWriter()))
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "form-group");
                writer.RenderBeginTag(HtmlTextWriterTag.Div);

                writer.RenderBeginTag(HtmlTextWriterTag.Label);
                writer.Write(_label);
                writer.RenderEndTag();

                switch (_inputType)
                {
                    case MockupInputType.Textbox:
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "form-control");
                        writer.AddAttribute(HtmlTextWriterAttribute.Type, "text");
                        writer.RenderBeginTag(HtmlTextWriterTag.Input);
                        writer.RenderEndTag();
                        break;

                    case MockupInputType.Selectlist:
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "form-control");
                        writer.RenderBeginTag(HtmlTextWriterTag.Select);

                        foreach (string option in _options)
                        {
                            writer.RenderBeginTag(HtmlTextWriterTag.Option);
                            writer.Write(option);
                            writer.RenderEndTag();
                        }

                        writer.RenderEndTag();
                        break;
                }

                writer.RenderEndTag();

                return new MvcHtmlString(writer.InnerWriter.ToString()).ToString();
            }
        }
    }
}
