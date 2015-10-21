namespace sidekick
{
    public class FormControl<TModel,TProperty> : HtmlElement<TModel,TProperty>
    {
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
    }
}
