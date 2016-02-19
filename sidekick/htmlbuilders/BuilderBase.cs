using System.IO;
using System.Web.Mvc;
using System.Web.Routing;
using System.Collections.Generic;

namespace sidekick
{
    public class BuilderBase<TModel>
    {
        protected HtmlHelper<TModel> Helper;
        private TextWriter _textWriter;

        public BuilderBase(HtmlHelper<TModel> helper)
        {
            Helper = helper;
            _textWriter = helper.ViewContext.Writer;
        }

        protected void WriteLine(object html)
        {
            _textWriter.Write(html);
        }

        protected IDictionary<string, object> MergeAttributes<TModel, TProperty>(FormControl<TModel, TProperty> element)
        {
            IDictionary<string, object> baseAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(element.BaseAttributes);
            IDictionary<string, object> additionalAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(element.HtmlAttributes);

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
    }
}
