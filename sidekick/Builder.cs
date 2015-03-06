using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace sidekick
{
    public static class Builder
    {
        public static string BuildElement<TElement>(Action<TElement> action) where TElement : IElement, new() {
            TElement element = new TElement();
            action(element);

            return new ViewBuilder().RenderView(element.ViewName, element);
        }

        /// <summary>
        ///     Builds a partial view using the AjaxAlert model that contains a list of the model state errors.
        /// </summary>
        /// <typeparam name="TAlert">Custom model that implements the IAlert interface.</typeparam>
        /// <param name="modelState"></param>
        /// <param name="viewName">View name</param>
        /// <returns></returns>
        public static string BuildModelErrorAlert<TAlert>(ModelStateDictionary modelState, string viewName) where TAlert : class, IAlert, new() {
            return BuildElement<TAlert>(x => { x.ViewName    = viewName;
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
            return new ViewBuilder().RenderView(viewName);
        }
    }
}
