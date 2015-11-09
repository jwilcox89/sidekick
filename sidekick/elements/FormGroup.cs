using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq.Expressions;

namespace sidekick
{
    public class FormGroup<TModel,TProperty> : FormControl<TModel,TProperty>
    {
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

        public FormGroup(Expression<Func<TModel,TProperty>> expression, IEnumerable<SelectListItem> listItems, string optionLabel, object textboxHtmlAttributes) {
            Expression = expression;
            HtmlAttributes = textboxHtmlAttributes;
            SelectListItems = listItems;
            OptionLabel = optionLabel;
            HasLabelWithColon = true;
            HasValidation = true;
        }
    }
}
