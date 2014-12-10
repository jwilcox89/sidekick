using System;

namespace sidekick
{
    public class Builder
    {
        private static ViewBuilder PartialBuilder { get; set; }

        public Builder() {
            PartialBuilder = new ViewBuilder();
        }

        /// <summary>
        ///     Builds a partial view and returns the HTML of the view in a string.
        /// </summary>
        /// <typeparam name="T">Model type for the view</typeparam>
        /// <param name="viewName">View name</param>
        /// <param name="action">Model with values that you wish to display in the element</param>
        /// <returns>A string of the HTML of the partial view specified.</returns>
        public static string BuildElement<T>(string viewName, Action<T> action) where T : class, new() {

            var element = new T();
            action(element);

            return PartialBuilder.RenderView(viewName, element);
        }

        /// <summary>
        ///     Builds a partial view and returns the HTML of a view that does not use a model.
        /// </summary>
        /// <param name="viewName">View name</param>
        /// <returns></returns>
        public static string BuildElement(string viewName) {
            return PartialBuilder.RenderView(viewName);
        }
    }
}
