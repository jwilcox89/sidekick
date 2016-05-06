using System.Collections.Generic;
using System.Web.Mvc;

namespace sidekick
{
    public static class BuilderHelper
    {
        public static IDictionary<string, object> MergeAttributes(object attributes1, object attributes2)
        {
            IDictionary<string, object> baseAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(attributes1);
            IDictionary<string, object> additionalAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(attributes2);

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

        public static void WriteLine(this HtmlHelper helper, object html)
        {
            helper.ViewContext.Writer.Write(html);
        }

        public static void WriteLine<TModel>(this HtmlHelper<TModel> helper, object html)
        {
            helper.ViewContext.Writer.Write(html);
        }
    }
}
