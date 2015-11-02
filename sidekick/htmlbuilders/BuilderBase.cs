using System.IO;
using System.Web.Mvc;

namespace sidekick
{
    public class BuilderBase<TModel>
    {
        protected HtmlHelper<TModel> _helper;
        protected TextWriter _textWriter;

        public BuilderBase(HtmlHelper<TModel> helper) {
            _helper = helper;
            _textWriter = helper.ViewContext.Writer;
        }

        public void WriteLine(string html) {
            _helper.ViewContext.Writer.Write(html);
        }

        public void WriteLine(object html) {
            _textWriter.Write(html);
        }
    }
}
