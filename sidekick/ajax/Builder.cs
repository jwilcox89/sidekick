using System;
using System.Web.Mvc;

namespace sidekick
{
    public class Builder : BuilderBase
    {
        /// <summary>
        ///     Builds a partial view and returns the HTML of the view in a string.
        /// </summary>
        /// <typeparam name="TElement">Model type for the view</typeparam>
        /// <param name="viewName">View name</param>
        /// <param name="action">Model with values that you wish to display in the element</param>
        /// <returns>A string of the HTML of the partial view specified.</returns>
        public static string BuildElement<TElement>(string viewName, Action<TElement> action) where TElement : class, new() {

            var element = new TElement();
            action(element);

            return MyBuilder.RenderView(viewName, element);
        }
    }
}
