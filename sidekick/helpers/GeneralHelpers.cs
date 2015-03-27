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

            action     = (string.IsNullOrEmpty(action)) ? currentAction : action;
            controller = (string.IsNullOrEmpty(controller)) ? currentController : controller;
            area       = (string.IsNullOrEmpty(area)) ? currentArea : area;

            if ((!string.IsNullOrEmpty(action + controller + area)) &&
                (string.IsNullOrEmpty(action) || action == currentAction) &&
                (string.IsNullOrEmpty(controller) || controller == currentController) &&
                (string.IsNullOrEmpty(area) || area == currentArea)) {

                return (string.IsNullOrEmpty(activeClass)) ? "active" : activeClass;
            }

            return string.Empty;
        }

        /// <summary>
        ///     Will return the active link css class if the current page is the link that was clicked.
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="action"></param>
        /// <param name="area">If this is not applicable then leave it as a null or empty string</param>
        /// <param name="activeClass">If this is not applicable then leave it as a null or empty string</param>
        /// <param name="controller">If "Home", "About", "Manage" is entered then this menu item will be marked as active if either of those three controllers are the current controllers</param>
        /// <returns></returns>
        public static string IsActiveNavItem(this HtmlHelper helper, string action, string area, string activeClass, params string[] controller) {
            RouteData routeData      = helper.ViewContext.RouteData;
            string currentAction     = (string)routeData.Values["action"];
            string currentController = (string)routeData.Values["controller"];
            string currentArea       = (string)routeData.DataTokens["area"];

            action = (string.IsNullOrEmpty(action)) ? currentAction : action;
            area   = (string.IsNullOrEmpty(area)) ? currentArea : area;

            if ((!string.IsNullOrEmpty(action + area)) &&
                (string.IsNullOrEmpty(action) || action == currentAction) &&
                (string.IsNullOrEmpty(area) || area == currentArea)) {

                foreach (string c in controller) {
                    string controllerName = (string.IsNullOrEmpty(c)) ? currentController : c;

                    if (string.IsNullOrEmpty(c) || controllerName == currentController)
                        return (string.IsNullOrEmpty(activeClass)) ? "active" : activeClass; 
                }

                return (string.IsNullOrEmpty(activeClass)) ? "active" : activeClass;
            }

            return string.Empty;
        }
    }
}
