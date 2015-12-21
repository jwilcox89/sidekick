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

        public void WriteLine(object html) 
        {
            _textWriter.Write(html);
        }

        public IDictionary<string,object> MergeAttributes<TModel,TProperty>(FormControl<TModel,TProperty> element) 
        {
            IDictionary<string,object> baseAttributes = ToDictionary(element.BaseAttributes);
            IDictionary<string,object> additionalAttributes = ToDictionary(element.HtmlAttributes);

            foreach (KeyValuePair<string,object> r in additionalAttributes) 
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

        private RouteValueDictionary ToDictionary(object data) 
        {
            return HtmlHelper.AnonymousObjectToHtmlAttributes(data);
        }
    }
}
