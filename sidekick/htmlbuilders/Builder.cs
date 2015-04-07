﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace sidekick
{
    public static class Builder
    {
        /// <summary>
        ///     Builds a partial view using a model that implements the IElement interface.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="action">The default view name is _AjaxMessage. If the view name you are using is different please specify.</param>
        /// <returns></returns>
        public static string BuildElement<TElement>(Action<TElement> action) where TElement : IElement, new() {
            TElement element = new TElement();
            action(element);

            if (string.IsNullOrEmpty(element.ViewName))
                element.ViewName = "_AjaxMessage";

            return new ViewBuilder().RenderView(element.ViewName, element);
        }

        /// <summary>
        ///     Builds a custom partial view that uses the AjaxAlert model
        /// </summary>
        /// <typeparam name="TAlert">Custom model that implements the IAlert interface</typeparam>
        /// <param name="action"></param>
        /// <returns></returns>
        public static string BuildAlert<TAlert>(Action<TAlert> action) where TAlert : IAlert, new() {
            return BuildElement<TAlert>(action);
        }

        /// <summary>
        ///     Builds a partial view using the AjaxAlert model that contains a list of the model state errors.
        /// </summary>
        /// <typeparam name="TAlert">Custom model that implements the IAlert interface.</typeparam>
        /// <param name="modelState"></param>
        /// <returns></returns>
        public static string BuildAlert<TAlert>(ModelStateDictionary modelState, string viewName = "_AjaxMessage") where TAlert : class, IAlert, new() {
            return BuildElement<TAlert>(x => { x.ViewName = viewName;
                                               x.MessageType = MessageTypes.Danger;
                                               x.Heading     = "Errors!";
                                               x.MessageList = modelState.GetModelErrors(); });
        }

        /// <summary>
        ///     Builds a custom partial view that uses the Modal model.
        /// </summary>
        /// <typeparam name="TModal">Custom model that implements the IModal interface</typeparam>
        /// <param name="action"></param>
        /// <returns></returns>
        public static string BuildModal<TModal>(Action<TModal> action) where TModal : IModal, new() {
            return BuildElement<TModal>(action);
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