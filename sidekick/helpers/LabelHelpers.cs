using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static MvcHtmlString LabelForWithColon<TModel,TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression) {
            return LabelFor(helper, expression, null);
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
        public static MvcHtmlString LabelForWithColon<TModel,TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes) {
            return LabelFor(helper, expression, new RouteValueDictionary(htmlAttributes));
        }

        private static MvcHtmlString LabelFor<TModel,TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, IDictionary<string,object> htmlAttributes) {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            string htmlFieldName   = ExpressionHelper.GetExpressionText(expression);
            string labelText       = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();

            if (String.IsNullOrEmpty(labelText))
                return MvcHtmlString.Empty;

            TagBuilder tag = new TagBuilder("label");

            if (htmlAttributes != null && htmlAttributes.Count > 0)
                tag.MergeAttributes(htmlAttributes);

            tag.Attributes.Add("for", helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));
            tag.SetInnerText(labelText + ":");
            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }
    }
}
