namespace sidekick
{
    public class Checkbox<T> where T : Checkbox<T>
    {
        internal bool _label;
        internal bool _labelWithColon;
        internal bool _isRequired;
        internal object _htmlAttributes;

        public T HasLabel()
        {
            _label = true;
            _labelWithColon = false;
            return (T)this;
        }

        public T HasLabelWithColon()
        {
            _label = false;
            _labelWithColon = true;
            return (T)this;
        }

        public T IsRequired()
        {
            _isRequired = true;
            return (T)this;
        }

        public T HtmlAttributes(object attributes)
        {
            _htmlAttributes = attributes;
            return (T)this;
        }
    }
}
