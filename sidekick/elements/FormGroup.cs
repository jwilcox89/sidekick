using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq.Expressions;

namespace sidekick
{
    public class FormGroup<TModel, TProperty> : FormControl<TModel, TProperty>
    {
        /// <summary>
        ///     Use this overload if you are creating a textbox
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="textboxHtmlAttributes"></param>
        public FormGroup(Expression<Func<TModel, TProperty>> expression, object textboxHtmlAttributes)
        {
            Expression = expression;
            HtmlAttributes = textboxHtmlAttributes;
            HasLabelWithColon = true;
            HasValidation = true;
        }

        /// <summary>
        ///     Use this overload if you are creating a dropdown list
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="listItems"></param>
        /// <param name="optionLabel"></param>
        /// <param name="textboxHtmlAttributes"></param>
        public FormGroup(Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> listItems, string optionLabel, object textboxHtmlAttributes)
        {
            Expression = expression;
            HtmlAttributes = textboxHtmlAttributes;
            SelectListItems = listItems;
            OptionLabel = optionLabel;
            HasLabelWithColon = true;
            HasValidation = true;
        }
    }
}
