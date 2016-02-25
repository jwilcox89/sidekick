namespace sidekick
{
    public class ActionLinkBase<T> where T : ActionLinkBase<T>
    {
        protected string REPLACEMENT_TEXT = "_replace_";
        protected string _controller;
        protected string _action;
        protected string _text;
        protected string _icon;
        protected object _routeValues;
        protected object _htmlAttributes;

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
