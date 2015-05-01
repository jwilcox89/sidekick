using System;
using System.Linq.Expressions;

namespace sidekick
{
    public class InputGroup<TModel,TProperty> : IInputGroup<TModel,TProperty>
    {
        public Expression<Func<TModel,TProperty>> Expression { get; set; }
        public object HtmlAttributes { get; set; }
        public string AppendText { get; set; }
        public string PrependText { get; set; }
        public string AppendIcon { get; set; }
        public string PrependIcon { get; set; }
        public InputGroupSize Size { get; set; }

        public InputGroup() {
            Size = InputGroupSize.Regular;
        }
    }
}
