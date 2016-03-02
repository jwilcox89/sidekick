using System.Collections.Generic;
using System.Web.Mvc;

namespace sidekick
{
    public static class BuilderHelper
    {
        public static IDictionary<string, object> MergeAttributes(object attributes, object htmlAttributes)
        {
            IDictionary<string, object> baseAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(attributes);
            IDictionary<string, object> additionalAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            foreach (KeyValuePair<string, object> r in additionalAttributes)
            {
                if (!baseAttributes.ContainsKey(r.Key))
                {
                    baseAttributes.Add(r.Key, r.Value);
                }
                else
                {
                    baseAttributes[r.Key] = baseAttributes[r.Key] + " " + r.Value;
                }
            }

            return baseAttributes;
        }

        public static void WriteLine<TModel>(this HtmlHelper<TModel> helper, object html)
        {
            helper.ViewContext.Writer.Write(html);
        }
    }
}
