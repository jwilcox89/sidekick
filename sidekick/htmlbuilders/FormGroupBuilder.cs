using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.UI;
using System.Linq.Expressions;
using System.IO;
using System.Collections.Generic;

namespace sidekick
{
    public class FormGroupBuilder<TModel,TProperty> : IHtmlString
    {
        private HtmlHelper<TModel> _helper;
        private FormGroup<TModel,TProperty> _model;

        public FormGroupBuilder(HtmlHelper<TModel> helper, Expression<Func<TModel,TProperty>> expression, object textboxHtmlAttributes) {
            _helper = helper;
            _model = new FormGroup<TModel,TProperty>(expression, textboxHtmlAttributes);
        }

        /// <summary>
        ///     Will hide label
        /// </summary>
        /// <returns></returns>
        public FormGroupBuilder<TModel,TProperty> NoLabel() {
            _model.HasLabel = false;
            _model.HasLabelWithColon = false;
            return this;
        }

        /// <summary>
        ///     Show label but without colon
        /// </summary>
        /// <returns></returns>
        public FormGroupBuilder<TModel,TProperty> HasLabelNoColon() {
            _model.HasLabelWithColon = false;
            _model.HasLabel = true;
            return this;
        }

        /// <summary>
        ///     Hide validation
        /// </summary>
        /// <returns></returns>
        public FormGroupBuilder<TModel,TProperty> NoValidation() {
            _model.HasValidation = false;
            return this;
        }

        /// <summary>
        ///     Will add the required '*' next to the label
        /// </summary>
        /// <returns></returns>
        public FormGroupBuilder<TModel,TProperty> IsRequired() {
            _model.IsRequired = true;
            return this;
        }

        private MvcHtmlString CreateFormGroup() {
            using (HtmlTextWriter writer = new HtmlTextWriter(new StringWriter())) {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "form-group");
                writer.RenderBeginTag(HtmlTextWriterTag.Div); // <div class=form-group>

                if (_model.HasLabelWithColon)
                    writer.Write(_helper.LabelForWithColon(_model.Expression, _model.IsRequired));

                if (_model.HasLabel)
                    writer.Write(_helper.LabelFor(_model.Expression));

                writer.Write(_helper.TextBoxFor(_model.Expression, _model.HtmlAttributes).ToString());

                if (_model.HasValidation)
                    writer.Write(_helper.ValidationMessageFor(_model.Expression));

                writer.RenderEndTag(); // </div>

                return new MvcHtmlString(writer.InnerWriter.ToString());
            }
        }

        public string ToHtmlString() {
            return CreateFormGroup().ToString();
        }
    }
}
