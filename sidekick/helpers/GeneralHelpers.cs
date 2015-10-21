using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace sidekick
{
    public static class GeneralHelpers
    {
        /// <summary>
        ///     Will return the active link css class if the current page is the link that was clicked.
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="action"></param>
        /// <param name="controller"></param>
        /// <param name="area"></param>
        /// <param name="activeClass"></param>
        /// <returns></returns>
        public static string IsActiveNavItem(this HtmlHelper helper, string action, string controller, string area = null, string activeClass = null) {
            RouteData routeData      = helper.ViewContext.RouteData;
            string currentAction     = (string)routeData.Values["action"];
            string currentController = (string)routeData.Values["controller"];
            string currentArea       = (string)routeData.DataTokens["area"];

            action     = (String.IsNullOrEmpty(action)) ? currentAction : action;
            controller = (String.IsNullOrEmpty(controller)) ? currentController : controller;
            area       = (String.IsNullOrEmpty(area)) ? currentArea : area;

            if ((!String.IsNullOrEmpty(action + controller + area)) &&
                (String.IsNullOrEmpty(action) || action == currentAction) &&
                (String.IsNullOrEmpty(controller) || controller == currentController) &&
                (String.IsNullOrEmpty(area) || area == currentArea)) {

                return (String.IsNullOrEmpty(activeClass)) ? "active" : activeClass;
            }

            return String.Empty;
        }

        /// <summary>
        ///     Will return the active link css class if the current page is the link that was clicked.
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="action">Current action</param>
        /// <param name="area">If this is not applicable then leave it as a null or empty string</param>
        /// <param name="activeClass">If this is not applicable then leave it as a null or empty string</param>
        /// <param name="controller">If "Home", "About", "Manage" is entered then this menu item will be marked as active if either of those three controllers are the current controllers</param>
        /// <returns></returns>
        public static string IsActiveNavItem(this HtmlHelper helper, string action, string area, string activeClass, params string[] controller) {
            RouteData routeData      = helper.ViewContext.RouteData;
            string currentAction     = (string)routeData.Values["action"];
            string currentController = (string)routeData.Values["controller"];
            string currentArea       = (string)routeData.DataTokens["area"];

            action = (String.IsNullOrEmpty(action)) ? currentAction : action;
            area   = (String.IsNullOrEmpty(area)) ? currentArea : area;

            if ((!String.IsNullOrEmpty(action + area)) &&
                (String.IsNullOrEmpty(action) || action == currentAction) &&
                (String.IsNullOrEmpty(area) || area == currentArea)) {

                foreach (string c in controller) {
                    string controllerName = (String.IsNullOrEmpty(c)) ? currentController : c;

                    if (String.IsNullOrEmpty(c) || controllerName == currentController)
                        return (String.IsNullOrEmpty(activeClass)) ? "active" : activeClass; 
                }
            }

            return String.Empty;
        }
    }
}
