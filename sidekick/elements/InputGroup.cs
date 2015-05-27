namespace sidekick
{
    public class InputGroup<TModel,TProperty> : HtmlElement<TModel,TProperty>
    {
        public virtual string AppendText { get; set; }
        public virtual string PrependText { get; set; }
        public virtual string AppendIcon { get; set; }
        public virtual string PrependIcon { get; set; }
        public virtual InputGroupSize Size { get; set; }

        public InputGroup() {
            Size = InputGroupSize.Regular;
        }
    }
}
