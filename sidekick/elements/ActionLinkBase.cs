namespace sidekick
{
    public class ActionLinkBase<T> where T : ActionLinkBase<T>
    {
        internal string REPLACEMENT_TEXT = "_replace_";
        internal string _controller;
        internal string _action;
        internal string _text;
        internal string _icon;
        internal object _routeValues;
        internal object _htmlAttributes;

        public T Icon(string icon)
        {
            _icon = icon;
            return (T)this;
        }

        public T RouteValues(object values)
        {
            _routeValues = values;
            return (T)this;
        }

        public T HtmlAttributes(object attributes)
        {
            _htmlAttributes = attributes;
            return (T)this;
        }
    }
}
