using System;
using System.Linq.Expressions;

namespace sidekick
{
    public class InputGroup<TModel,TProperty> : FormControl<TModel,TProperty>
    {
        /// <summary>
        ///     Text to append to the input group
        /// </summary>
        public virtual string AppendText { get; set; }

        /// <summary>
        ///     Text to prepend to the input group
        /// </summary>
        public virtual string PrependText { get; set; }

        /// <summary>
        ///     Icon to append to the input group
        /// </summary>
        public virtual string AppendIcon { get; set; }

        /// <summary>
        ///     Icon to prepend to the input group
        /// </summary>
        public virtual string PrependIcon { get; set; }

        /// <summary>
        ///     Size of the input group
        /// </summary>
        public virtual InputGroupSize Size { get; set; }

        /// <summary>
        ///     Css class for datetimepicker
        /// </summary>
        public virtual string DatetimepickerClass { get; set; }

        /// <summary>
        ///     Id for datetimepicker
        /// </summary>
        public virtual string DatetimepickerId { get; set; }

        public InputGroup(Expression<Func<TModel,TProperty>> expression, object textboxHtmlAttributes) {
            Expression = expression;
            HtmlAttributes = textboxHtmlAttributes;
            Size = InputGroupSize.Regular;
        }
    }
}
