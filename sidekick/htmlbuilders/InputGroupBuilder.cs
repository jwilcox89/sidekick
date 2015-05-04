using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.UI;
using System.Linq.Expressions;
using System.IO;

namespace sidekick
{
    public class InputGroupBuilder<TModel,TProperty> : IHtmlString
    {
        private HtmlHelper<TModel> _helper;
        private InputGroup<TModel,TProperty> _model;

        public InputGroupBuilder(HtmlHelper<TModel> helper, Expression<Func<TModel,TProperty>> expression, object htmlAttributes) {
            _helper = helper;
            _model = new InputGroup<TModel,TProperty>();
            _model.Expression = expression;
            _model.HtmlAttributes = htmlAttributes;
        }

        public InputGroupBuilder<TModel,TProperty> PrependIcon(string icon) {
            _model.PrependIcon = icon;
            return this;
        }

        public InputGroupBuilder<TModel,TProperty> PrependText(string text) {
            _model.PrependText = text;
            return this;
        }

        public InputGroupBuilder<TModel,TProperty> AppendIcon(string icon) {
            _model.AppendIcon = icon;
            return this;
        }

        public InputGroupBuilder<TModel,TProperty> AppendText(string text) {
            _model.AppendText = text;
            return this;
        }

        public InputGroupBuilder<TModel,TProperty> Size(InputGroupSize size) {
            _model.Size = size;
            return this;
        }

        private MvcHtmlString CreateInputGroup() {
            using (HtmlTextWriter writer = new HtmlTextWriter(new StringWriter())) {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, string.Format("input-group {0}", _model.Size.GetHtmlAttributes<InputGroupSize>().Class));
                writer.RenderBeginTag(HtmlTextWriterTag.Div); // <div class=input-group>

                if (!string.IsNullOrEmpty(_model.PrependIcon) || !string.IsNullOrEmpty(_model.PrependText)) {
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, "input-group-addon");
                    writer.RenderBeginTag(HtmlTextWriterTag.Div);

                    if (!string.IsNullOrEmpty(_model.PrependIcon))
                        writer.Write(string.Format("<i class='{0}'></i>", _model.PrependIcon));

                    if (!string.IsNullOrEmpty(_model.PrependText))
                        writer.Write(string.Format(" {0}", _model.PrependText)); 

                    writer.RenderEndTag();
                }

                writer.Write(_helper.TextBoxFor(_model.Expression, _model.HtmlAttributes).ToString());

                if (!string.IsNullOrEmpty(_model.AppendIcon) || !string.IsNullOrEmpty(_model.AppendText)) {
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, "input-group-addon");
                    writer.RenderBeginTag(HtmlTextWriterTag.Div);

                    if (!string.IsNullOrEmpty(_model.AppendIcon))
                        writer.Write(string.Format("<i class='{0}'></i>", _model.AppendIcon));

                    if (!string.IsNullOrEmpty(_model.AppendText))
                        writer.Write(string.Format(" {0}", _model.AppendText)); 

                    writer.RenderEndTag();
                }

                writer.RenderEndTag(); // </div>

                return new MvcHtmlString(writer.InnerWriter.ToString());
            }
        }

        public string ToHtmlString() {
            return CreateInputGroup().ToString();
        }
    }
}
