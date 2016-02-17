﻿using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Web.Mvc;

namespace sidekick
{
    public class FormControl<TModel, TProperty>
    {
        /// <summary>
        ///     An expression that identifies the property to display.
        /// </summary>
        public Expression<Func<TModel, TProperty>> Expression { get; set; }

        /// <summary>
        ///     An object that contains the HTML attributes to set for the element.
        /// </summary>
        public object HtmlAttributes { get; set; }

        /// <summary>
        ///     True if label has no colon.
        /// </summary>
        public virtual bool HasLabel { get; set; }

        /// <summary>
        ///     True if label requires a colon.
        /// </summary>
        public virtual bool HasLabelWithColon { get; set; }

        /// <summary>
        ///     True if from group requires validation.
        /// </summary>
        public virtual bool HasValidation { get; set; }

        /// <summary>
        ///     True if the field is required and you want to include a required '*' next to the label.
        /// </summary>
        public virtual bool IsRequired { get; set; }

        /// <summary>
        ///     Base html attributes
        /// </summary>
        public virtual object BaseAttributes { get; set; }

        /// <summary>
        ///     Help text that will show below the form control
        /// </summary>
        public virtual string HelpText { get; set; }

        /// <summary>
        ///     List of items for a dropdown list
        /// </summary>
        public virtual IEnumerable<SelectListItem> SelectListItems { get; set; }

        /// <summary>
        ///     Text for top element of dropdown list
        /// </summary>
        public virtual string OptionLabel { get; set; }

        public FormControl()
        {
            if (BaseAttributes == null)
                BaseAttributes = new { @class = "form-control" };
        }
    }
}
