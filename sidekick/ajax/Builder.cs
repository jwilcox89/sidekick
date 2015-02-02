using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace sidekick
{
    public static class Builder
    {
        private static ViewBuilder PartialBuilder = new ViewBuilder();

        public static string BuildElement<T>(Action<T> action) where T : IElement, new() {
            T element = new T();
            action(element);

            return PartialBuilder.RenderView(element.ViewName, element);
        }

        /// <summary>
        ///     Builds a partial view using the AjaxAlert model that contains a list of the model state errors.
        /// </summary>
        /// <typeparam name="T">Custom model that implements the IAlert interface.</typeparam>
        /// <param name="modelState"></param>
        /// <param name="viewName">View name</param>
        /// <returns></returns>
        public static string BuildModelErrorAlert<T>(ModelStateDictionary modelState, string viewName) where T : class, IAlert, new() {
            return BuildElement<T>(x => { x.ViewName    = viewName;
                                          x.MessageType = MessageTypes.Danger;
                                          x.Heading     = "Errors!";
                                          x.MessageList = ErrorHandler.GetModelErrors(modelState); });
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
