namespace sidekick
{
    public class ActionLinkBase<T> where T : ActionLinkBase<T>
    {
        internal string REPLACEMENT_TEXT = "_replace_";

        /// <summary>
        ///     Controller used in the action link
        /// </summary>
        internal string _controller;

        /// <summary>
        ///     Action used in the action link
        /// </summary>
        internal string _action;

        /// <summary>
        ///     Text used to display the action link
        /// </summary>
        internal string _text;

        /// <summary>
        ///     Icon used to the left of the text in the action link
        /// </summary>
        internal string _icon;

        /// <summary>
        ///     Route value(s) for the action link
        /// </summary>
        internal object _routeValues;

        /// <summary>
        ///     HTML attirbutes for the action link element
        /// </summary>
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