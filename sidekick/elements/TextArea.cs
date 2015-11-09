using System;
using System.Linq.Expressions;

namespace sidekick
{
    public class TextArea<TModel,TProperty> : FormControl<TModel,TProperty>
    {
        /// <summary>
        ///     Number of rows in the textarea
        /// </summary>
        public virtual int Rows { get; set; }
        
        /// <summary>
        ///     Number of columns in the textarea
        /// </summary>
        public virtual int Columns { get; set; }

        public TextArea(Expression<Func<TModel,TProperty>> expression, object textboxHtmlAttributes) {
            Expression = expression;
            HtmlAttributes = textboxHtmlAttributes;
            HasLabelWithColon = true;
            HasValidation = true;
        }
    }
}
