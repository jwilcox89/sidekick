using System.Web.Mvc;

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
        public static string IsCurrentPage(this HtmlHelper helper, string action, string controller, string activeClass = null) {

            var routeData         = helper.ViewContext.RouteData;
            var currentAction     = (string)routeData.Values["action"];
            var currentController = (string)routeData.Values["controller"];

            if (!(currentAction == action && currentController == controller))
                return string.Empty;

            return (!string.IsNullOrEmpty(activeClass)) ? activeClass : "active";
        }
    }
}
