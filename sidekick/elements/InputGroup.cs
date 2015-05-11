namespace sidekick
{
    public class InputGroup<TModel,TProperty> : HtmlElement<TModel,TProperty>
    {
        public string AppendText { get; set; }
        public string PrependText { get; set; }
        public string AppendIcon { get; set; }
        public string PrependIcon { get; set; }
        public InputGroupSize Size { get; set; }

        public InputGroup() {
            Size = InputGroupSize.Regular;
        }
    }
}
