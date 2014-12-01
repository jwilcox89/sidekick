using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq.Expressions;

namespace sidekick
{
    public static class LabelHelpers
    {
        /// <summary>
        ///     Adds a colon to the end of the display name
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="html"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static MvcHtmlString LabelForWithColon<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression) {
            return LabelFor(html, expression, null);
        }

        /// <summary>
        ///     Adds a colon to the end of the display name
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="html"></param>
        /// <param name="expression"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString LabelForWithColon<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes) {
            return LabelFor(html, expression, new RouteValueDictionary(htmlAttributes));
        }

        private static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes) {

            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            string htmlFieldName   = ExpressionHelper.GetExpressionText(expression);
            string labelText       = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();

            if (String.IsNullOrEmpty(labelText)) {
                return MvcHtmlString.Empty;
            }

            TagBuilder tag = new TagBuilder("label");

            if (htmlAttributes != null && htmlAttributes.Count > 0) {
                tag.MergeAttributes(htmlAttributes);
            }

            tag.Attributes.Add("for", html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));
            tag.SetInnerText(labelText + ":");
            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }
    }
}
