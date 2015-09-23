using System;
using System.Linq.Expressions;

namespace sidekick
{
    public class Datetimepicker<TModel,TProperty> : InputGroup<TModel,TProperty>
    {
        /// <summary>
        ///     ID for the Div surrounding the datetimepicker. Will be used when initializing the jQuery method.
        /// </summary>
        public virtual string ID { get; set; }

        public Datetimepicker(Expression<Func<TModel,TProperty>> expression, string id, object textboxHtmlAttributes)
            : base(expression, textboxHtmlAttributes) {
            ID = id;
        }
    }
}
