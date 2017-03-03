using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.Routing;
using System.Collections.Generic;
using System.IO;

namespace sidekick
{
    /// <summary>
    ///     HTML builders for label elements
    /// </summary>
    public static class LabelBuilder
    {
        /// <summary>
        ///     Adds a colon to the end of the display name
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="required"></param>
        /// <returns></returns>
        public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, string appendText, bool required = false)
        {
            return LabelFor(helper, expression, null, appendText, required);
        }

        /// <summary>
        ///     Adds a colon to the end of the display name
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="html"></param>
        /// <param name="expression"></param>
        /// <param name="htmlAttributes"></param>
        /// <param name="required"></param>
        /// <returns></returns>
        public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes, string appendText, bool required = false)
        {
            return LabelFor(helper, expression, new RouteValueDictionary(htmlAttributes), appendText, required);
        }

        private static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes, string appendText, bool required)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();

            if (String.IsNullOrEmpty(labelText)) return MvcHtmlString.Empty;

            TagBuilder tag = new TagBuilder("label");
            if (htmlAttributes != null && htmlAttributes.Any())
                tag.MergeAttributes(htmlAttributes);

            tag.Attributes.Add("for", helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));
            if (required)
                tag.Attributes.Add("class", "required-field");

            tag.SetInnerText(!String.IsNullOrEmpty(appendText) ? $"{labelText}{appendText}" : labelText);
            return new MvcHtmlString(tag.ToString(TagRenderMode.Normal));
        }
    }
}