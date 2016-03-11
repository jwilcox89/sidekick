namespace sidekick
{
    public class Checkbox
    {
        internal bool _label;
        internal bool _labelWithColon;
        internal bool _isRequired;
        internal object _htmlAttributes;

        public Checkbox HasLabel()
        {
            _label = true;
            _labelWithColon = false;
            return this;
        }

        public Checkbox HasLabelWithColon()
        {
            _label = false;
            _labelWithColon = true;
            return this;
        }

        public Checkbox IsRequired()
        {
            _isRequired = true;
            return this;
        }

        public Checkbox HtmlAttributes(object attributes)
        {
            _htmlAttributes = attributes;
            return this;
        }
    }
}
