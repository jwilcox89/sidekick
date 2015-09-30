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
            _model = new InputGroup<TModel,TProperty>(expression, htmlAttributes);
        }

        public InputGroupBuilder<TModel,TProperty> PrependIcon(string icon) {
            _model.PrependIcon = icon;
            return this;
        }

        public InputGroupBuilder<TModel,TProperty> AppendIcon(string icon) {
            _model.AppendIcon = icon;
            return this;
        }

        public InputGroupBuilder<TModel,TProperty> PrependText(string text) {
            _model.PrependText = text;
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

        public InputGroupBuilder<TModel,TProperty> ShowLabel() {
            _model.ShowLabel = true;
            return this;
        }

        public InputGroupBuilder<TModel,TProperty> IsRequired() {
            _model.IsRequired = true;
            return this;
        }

        public InputGroupBuilder<TModel,TProperty> DatetimepickerCss(string @class) {
            _model.DatetimepickerClass = @class;
            return this;
        }

        public InputGroupBuilder<TModel,TProperty> DatetimepickerId(string id) {
            _model.DatetimepickerId = id;
            return this;
        }

        private MvcHtmlString CreateInputGroup() {
            using (HtmlTextWriter writer = new HtmlTextWriter(new StringWriter())) {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "form-group");
                writer.RenderBeginTag(HtmlTextWriterTag.Div);

                if (_model.ShowLabel)
                    writer.Write(_helper.LabelForWithColon(_model.Expression, _model.IsRequired));

                writer.AddAttribute(HtmlTextWriterAttribute.Class, String.Format("input-group {0} {1}", _model.Size.GetHtmlAttributes<InputGroupSize>().Class, _model.DatetimepickerClass));
                writer.AddAttribute(HtmlTextWriterAttribute.Id, _model.DatetimepickerId);
                writer.RenderBeginTag(HtmlTextWriterTag.Div); // <div class=input-group>

                if (!String.IsNullOrEmpty(_model.PrependIcon) || !String.IsNullOrEmpty(_model.PrependText)) {
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, "input-group-addon");
                    writer.RenderBeginTag(HtmlTextWriterTag.Span);

                    if (!String.IsNullOrEmpty(_model.PrependIcon))
                        writer.Write(String.Format("<i class='{0}'></i>", _model.PrependIcon));

                    if (!String.IsNullOrEmpty(_model.PrependText))
                        writer.Write(String.Format(" {0}", _model.PrependText)); 

                    writer.RenderEndTag();
                }

                writer.Write(_helper.TextBoxFor(_model.Expression, _model.HtmlAttributes).ToString());

                if (!String.IsNullOrEmpty(_model.AppendIcon) || !String.IsNullOrEmpty(_model.AppendText)) {
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, "input-group-addon");
                    writer.RenderBeginTag(HtmlTextWriterTag.Span);

                    if (!String.IsNullOrEmpty(_model.AppendIcon))
                        writer.Write(String.Format("<i class='{0}'></i>", _model.AppendIcon));

                    if (!String.IsNullOrEmpty(_model.AppendText))
                        writer.Write(String.Format(" {0}", _model.AppendText)); 

                    writer.RenderEndTag();
                }

                writer.RenderEndTag(); // </div>
                writer.RenderEndTag();

                return new MvcHtmlString(writer.InnerWriter.ToString());
            }
        }

        public string ToHtmlString() {
            return CreateInputGroup().ToString();
        }
    }
}
