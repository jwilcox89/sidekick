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
        /// <param name="activeClass"></param>
        /// <returns></returns>
        public static string IsActiveNavItem(this HtmlHelper helper, string action, string controller, string activeClass = null) {
            RouteData routeData      = helper.ViewContext.RouteData;
            string currentAction     = routeData.Values["action"].ToString();
            string currentController = routeData.Values["controller"].ToString();

            if (!(currentAction == action && currentController == controller))
                return string.Empty;

            return (string.IsNullOrEmpty(activeClass)) ? "active" : activeClass;
        }
    }
}
