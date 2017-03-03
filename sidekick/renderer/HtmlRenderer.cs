namespace sidekick
{
    public static class HtmlRenderer
    {
        /// <summary>
        ///     Render Partial View
        /// </summary>
        /// <param name="viewName">Name of partial view to be rendered</param>
        /// <returns></returns>
        public static string BuildHtml(string viewName)
        {
            return new ViewBuilder().RenderView(viewName);
        }

        /// <summary>
        ///     Render html
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="viewName">Partial view to be rendered</param>
        /// <param name="element">Object to be passed into view<</param>
        /// <returns></returns>
        public static string BuildHtml(string viewName, object element)
        {
            return new ViewBuilder().RenderView(viewName, element);
        }

        /// <summary>
        ///     Render html
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="viewName">Partial view to be rendered</param>
        /// <param name="element">Object to be passed into view</param>
        /// <param name="tempData">Additional temp data</param>
        /// <returns></returns>
        public static string BuildHtml(string viewName, object element, object tempData)
        {
            return new ViewBuilder().RenderView(viewName, element, tempData);
        }
    }
}