using System;

namespace sidekick
{
    /// <summary>
    ///     Render partial views with objects or temp data passed into them
    /// </summary>
    public static class HtmlRenderer
    {
        public static string BuildHtml<TModel>(Action<TModel> action, string viewName)
            where TModel : new()
        {
            TModel element = new TModel();
            action(element);

            using (ViewBuilder builder = new ViewBuilder())
            {
                return builder.RenderView(viewName, element);
            }
        }

        public static string BuildHtml(string viewName)
        {
            using (ViewBuilder builder = new ViewBuilder())
            {
                return builder.RenderView(viewName);
            }
        }

        public static string BuildHtml<TModel>(TModel element, string viewName)
        {
            using (ViewBuilder builder = new ViewBuilder())
            {
                return builder.RenderView(viewName, element);
            }
        }

        public static string BuildHtml<TModel>(TModel element, string viewName, object tempData)
        {
            using (ViewBuilder builder = new ViewBuilder())
            {
                return builder.RenderView(viewName, element, tempData);
            }
        }
    }
}
