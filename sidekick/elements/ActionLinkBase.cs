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

        /// <summary>
        ///     Set the icon to be used with the link
        /// </summary>
        /// <param name="icon"></param>
        /// <returns></returns>
        public T Icon(string icon)
        {
            _icon = icon;
            return (T)this;
        }

        /// <summary>
        ///     Set the route values to be used with the link
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public T RouteValues(object values)
        {
            _routeValues = values;
            return (T)this;
        }

        /// <summary>
        ///     Set additional html attributes for the link
        /// </summary>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public T HtmlAttributes(object attributes)
        {
            _htmlAttributes = attributes;
            return (T)this;
        }
    }
}