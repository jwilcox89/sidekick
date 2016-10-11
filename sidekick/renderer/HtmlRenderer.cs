using System;

namespace sidekick
{
    /// <summary>
    ///     Render partial views with objects or temp data passed into them
    /// </summary>
    public static class HtmlRenderer
    {
        /// <summary>
        ///     Render html
        /// </summary>
        /// <param name="viewName">Partial view to be rendered</param>
        /// <returns></returns>
        public static string BuildHtml(string viewName)
        {
            using (ViewBuilder builder = new ViewBuilder())
            {
                return builder.RenderView(viewName);
            }
        }

        /// <summary>
        ///     Render html
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="element">Object to be passed into view<</param>
        /// <param name="viewName">Partial view to be rendered</param>
        /// <returns></returns>
        public static string BuildHtml<TModel>(TModel element, string viewName)
        {
            using (ViewBuilder builder = new ViewBuilder())
            {
                return builder.RenderView(viewName, element);
            }
        }

        /// <summary>
        ///     Render html
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="element">Object to be passed into view</param>
        /// <param name="viewName">Partial view to be rendered</param>
        /// <param name="tempData">Additional temp data</param>
        /// <returns></returns>
        public static string BuildHtml<TModel>(TModel element, string viewName, object tempData)
        {
            using (ViewBuilder builder = new ViewBuilder())
            {
                return builder.RenderView(viewName, element, tempData);
            }
        }
    }
}
