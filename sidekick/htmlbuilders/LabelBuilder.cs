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

            if (String.IsNullOrEmpty(labelText))
                return MvcHtmlString.Empty;

            TagBuilder tag = new TagBuilder("label");

            if (htmlAttributes != null && htmlAttributes.Any())
                tag.MergeAttributes(htmlAttributes);

            tag.Attributes.Add("for", helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));
            if (!String.IsNullOrEmpty(appendText))
            {
                tag.SetInnerText($"{labelText}{appendText}");
            }
            else
            {
                tag.SetInnerText(labelText);
            }

            string result = tag.ToString(TagRenderMode.Normal);

            if (required)
            {
                TagBuilder requiredTag = new TagBuilder("span");
                requiredTag.Attributes.Add("class", "required");
                requiredTag.SetInnerText("*");
                result = $"{result} {requiredTag.ToString(TagRenderMode.Normal)}";
            }

            return new MvcHtmlString(result);
        }
    }
}













//using System;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Web.Mvc;
//using System.Web.UI;
//using System.Web.Routing;
//using System.Collections.Generic;
//using System.IO;

//namespace sidekick
//{
//    /// <summary>
//    ///     HTML builders for label elements
//    /// </summary>
//    public static class LabelBuilder
//    {
//        /// <summary>
//        ///     Builds a bootstrap label
//        /// </summary>
//        /// <param name="color"></param>
//        /// <param name="text"></param>
//        /// <returns></returns>
//        public static MvcHtmlString BuildLabel(this HtmlHelper helper, Colors color, string text)
//        {
//            using (HtmlTextWriter writer = new HtmlTextWriter(new StringWriter()))
//            {
//                writer.AddAttribute(HtmlTextWriterAttribute.Class, $"label label-{color.GetAttribute<HtmlBuilderAttribute>().Class}");
//                writer.RenderBeginTag(HtmlTextWriterTag.Span);
//                writer.Write(text);
//                writer.RenderEndTag();

//                return new MvcHtmlString(writer.InnerWriter.ToString());
//            }
//        }

//        /// <summary>
//        ///     Adds a colon to the end of the display name
//        /// </summary>
//        /// <typeparam name="TModel"></typeparam>
//        /// <typeparam name="TValue"></typeparam>
//        /// <param name="helper"></param>
//        /// <param name="expression"></param>
//        /// <param name="required"></param>
//        /// <returns></returns>
//        public static MvcHtmlString LabelForWithColon<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, bool required = false)
//        {
//            return LabelFor(helper, expression, null, true, required);
//        }

//        /// <summary>
//        ///     Builds label with no colon
//        /// </summary>
//        /// <typeparam name="TModel"></typeparam>
//        /// <typeparam name="TValue"></typeparam>
//        /// <param name="helper"></param>
//        /// <param name="expression"></param>
//        /// <param name="required"></param>
//        /// <returns></returns>
//        public static MvcHtmlString LabelForNoColon<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, bool required = false)
//        {
//            return LabelFor(helper, expression, null, false, required);
//        }

//        /// <summary>
//        ///     Adds a colon to the end of the display name
//        /// </summary>
//        /// <typeparam name="TModel"></typeparam>
//        /// <typeparam name="TValue"></typeparam>
//        /// <param name="html"></param>
//        /// <param name="expression"></param>
//        /// <param name="htmlAttributes"></param>
//        /// <param name="required"></param>
//        /// <returns></returns>
//        public static MvcHtmlString LabelForWithColon<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes, bool required = false)
//        {
//            return LabelFor(helper, expression, new RouteValueDictionary(htmlAttributes), true, required);
//        }

//        /// <summary>
//        ///     Builds a label with no colon
//        /// </summary>
//        /// <typeparam name="TModel"></typeparam>
//        /// <typeparam name="TValue"></typeparam>
//        /// <param name="helper"></param>
//        /// <param name="expression"></param>
//        /// <param name="htmlAttributes"></param>
//        /// <param name="required"></param>
//        /// <returns></returns>
//        public static MvcHtmlString LabelForNoColon<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes, bool required = false)
//        {
//            return LabelFor(helper, expression, new RouteValueDictionary(htmlAttributes), false, required);
//        }

//        private static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes, bool hasColon, bool required)
//        {
//            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
//            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
//            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();

//            if (String.IsNullOrEmpty(labelText))
//                return MvcHtmlString.Empty;

//            TagBuilder tag = new TagBuilder("label");

//            if (htmlAttributes != null && htmlAttributes.Any())
//                tag.MergeAttributes(htmlAttributes);

//            tag.Attributes.Add("for", helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));
//            if (hasColon)
//            {
//                tag.SetInnerText(labelText + ":");
//            }
//            else
//            {
//                tag.SetInnerText(labelText);
//            }

//            string result = tag.ToString(TagRenderMode.Normal);

//            if (required)
//            {
//                TagBuilder requiredTag = new TagBuilder("span");
//                requiredTag.Attributes.Add("class", "required");
//                requiredTag.SetInnerText("*");
//                result = $"{result} {requiredTag.ToString(TagRenderMode.Normal)}";
//            }

//            return new MvcHtmlString(result);
//        }
//    }
//}
