using System;
using System.Linq.Expressions;

namespace sidekick
{
    public class HtmlElement<TModel,TProperty>
    {
        /// <summary>
        ///     An expression that identifies the property to display.
        /// </summary>
        public Expression<Func<TModel,TProperty>> Expression { get; set; }

        /// <summary>
        ///     An object that contains the HTML attributes to set for the element.
        /// </summary>
        public object HtmlAttributes { get; set; }
    }
}
