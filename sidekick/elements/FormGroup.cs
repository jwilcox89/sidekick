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

        public FormGroup() {
            HasLabelWithColon = true;
            HasValidation = true;
        }
    }
}
