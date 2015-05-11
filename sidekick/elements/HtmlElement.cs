using System;
using System.Linq.Expressions;

namespace sidekick
{
    public class HtmlElement<TModel,TProperty>
    {
        public Expression<Func<TModel,TProperty>> Expression { get; set; }
        public object HtmlAttributes { get; set; }
    }
}
