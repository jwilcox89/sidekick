using System;
using System.Linq.Expressions;

namespace sidekick
{
    public class FormGroup<TModel,TProperty>
    {
        public Expression<Func<TModel,TProperty>> Expression { get; set; }
        public object HtmlAttributes { get; set; }

        /// <summary>
        ///     True if label has no colon. Default value = false
        /// </summary>
        public bool HasLabel { get; set; }

        /// <summary>
        ///     True if label requires a colon. Default value = true
        /// </summary>
        public bool HasLabelWithColon { get; set; }

        /// <summary>
        ///     True if from group requires validation. Default value = true
        /// </summary>
        public bool HasValidation { get; set; }

        /// <summary>
        ///     True if the field is required and you want to include a required '*' next to the label. Default value = false
        /// </summary>
        public bool IsRequired { get; set; }

        public FormGroup() {
            HasLabelWithColon = true;
            HasValidation = true;
        }
    }
}
