using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.UI;
using System.Linq.Expressions;
using System.IO;

namespace sidekick
{
    public class DatetimepickerBuilder<TModel,TProperty> : IHtmlString
    {
        private HtmlHelper<TModel> _helper;
        private Datetimepicker<TModel,TProperty> _model;

        public DatetimepickerBuilder(HtmlHelper<TModel> helper, Expression<Func<TModel,TProperty>> expression, string id, object htmlAttributes) {
            _helper = helper;
            _model = new Datetimepicker<TModel,TProperty>(expression, id, htmlAttributes);
        }

        public DatetimepickerBuilder<TModel,TProperty> PrependIcon(string icon) {
            _model.PrependIcon = icon;
            return this;
        }

        public DatetimepickerBuilder<TModel,TProperty> AppendIcon(string icon) {
            _model.AppendIcon = icon;
            return this;
        }

        public DatetimepickerBuilder<TModel,TProperty> PrependText(string text) {
            _model.PrependText = text;
            return this;
        }

        public DatetimepickerBuilder<TModel,TProperty> AppendText(string text) {
            _model.AppendText = text;
            return this;
        }

        public DatetimepickerBuilder<TModel,TProperty> Size(InputGroupSize size) {
            _model.Size = size;
            return this;
        }

        private MvcHtmlString CreateDatetimepicker() {
            using (HtmlTextWriter writer = new HtmlTextWriter(new StringWriter())) {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, String.Format("input-group {0} date", _model.Size.GetHtmlAttributes<InputGroupSize>().Class));
                writer.AddAttribute(HtmlTextWriterAttribute.Id, _model.ID);
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

                return new MvcHtmlString(writer.InnerWriter.ToString());
            }
        }

        public string ToHtmlString() {
            return CreateDatetimepicker().ToString();
        }
    }
}
