using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq.Expressions;

namespace sidekick
{
    public class FormGroup<TModel,TProperty> : HtmlElement<TModel,TProperty>
    {
        /// <summary>
        ///     True if label has no colon. Default value = false
        /// </summary>
        public virtual bool HasLabel { get; set; }

        /// <summary>
        ///     True if label requires a colon. Default value = true
        /// </summary>
        public virtual bool HasLabelWithColon { get; set; }

        /// <summary>
        ///     True if from group requires validation. Default value = true
        /// </summary>
        public virtual bool HasValidation { get; set; }

        /// <summary>
        ///     True if the field is required and you want to include a required '*' next to the label. Default value = false
        /// </summary>
        public virtual bool IsRequired { get; set; }

        /// <summary>
        ///     List of items for a dropdown list
        /// </summary>
        public virtual IEnumerable<SelectListItem> SelectListItems { get; set; }

        /// <summary>
        ///     Text for top element of dropdown list
        /// </summary>
        public virtual string OptionLabel { get; set; }

        public FormGroup(Expression<Func<TModel,TProperty>> expression, object textboxHtmlAttributes) {
            Expression = expression;
            HtmlAttributes = textboxHtmlAttributes;
            HasLabelWithColon = true;
            HasValidation = true;
        }

        public FormGroup(Expression<Func<TModel,TProperty>> expression, IEnumerable<SelectListItem> listItems, object textboxHtmlAttributes, string optionLabel) {
            Expression = expression;
            HtmlAttributes = textboxHtmlAttributes;
            SelectListItems = listItems;
            OptionLabel = optionLabel;
            HasLabelWithColon = true;
            HasValidation = true;
        }
    }
}
