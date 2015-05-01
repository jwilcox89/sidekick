using System;
using System.Linq.Expressions;

namespace sidekick
{
    public interface IInputGroup<TModel,TProperty>
    {
        Expression<Func<TModel,TProperty>> Expression { get; set; }
        object HtmlAttributes { get; set; }
        string AppendText { get; set; }
        string PrependText { get; set; }
        string AppendIcon { get; set; }
        string PrependIcon { get; set; }
        InputGroupSize Size { get; set; }
    }
}
