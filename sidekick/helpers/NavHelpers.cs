using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace sidekick
{
    /// <summary>
    ///     Extensions used to return a true/false as to if the navigation element should be considered active.
    /// </summary>
    public static class NavHelpers
    {
        public static string IsActiveNavItem(this HtmlHelper helper, string controllers)
        {
            return IsActiveNavItem(helper, controllers, null, null, new KeyValuePair<string, string>(), null);
        }

        public static string IsActiveNavItem(this HtmlHelper helper, string controllers, string actions)
        {
            return IsActiveNavItem(helper, controllers, actions, null, new KeyValuePair<string, string>(), null);
        }

        public static string IsActiveNavItem(this HtmlHelper helper, string controllers, string actions, string areas)
        {
            return IsActiveNavItem(helper, controllers, actions, areas, new KeyValuePair<string, string>(), null);
        }

        public static string IsActiveNavItem(this HtmlHelper helper, string controllers, string actions, string areas, KeyValuePair<string, string> routeParam)
        {
            return IsActiveNavItem(helper, controllers, actions, areas, routeParam, null);
        }

        public static string IsActiveNavItem(this HtmlHelper helper, string controllers, string actions, string areas, KeyValuePair<string, string> routeParam, string activeClass)
        {
            activeClass = (String.IsNullOrEmpty(activeClass)) ? "active" : activeClass;
            RouteData routeData = helper.ViewContext.RouteData;
            string currentAction = (string)routeData.Values["action"];
            string currentController = (string)routeData.Values["controller"];
            string currentArea = (string)routeData.DataTokens["area"];
            if (String.IsNullOrEmpty(currentArea))
                currentArea = String.Empty;

            actions = (String.IsNullOrEmpty(actions)) ? currentAction : actions;
            controllers = (String.IsNullOrEmpty(controllers)) ? currentController : controllers;
            areas = (String.IsNullOrEmpty(areas)) ? currentArea : areas;

            if (String.IsNullOrEmpty(actions))
                actions = String.Empty;

            if (String.IsNullOrEmpty(controllers))
                controllers = String.Empty;

            if (String.IsNullOrEmpty(areas))
                areas = String.Empty;

            IEnumerable<string> acceptedActions = actions.Split(',').Select(x => x.Trim()).Distinct();
            IEnumerable<string> acceptedControllers = controllers.Split(',').Select(x => x.Trim()).Distinct();
            IEnumerable<string> acceptedAreas = areas.Split(',').Select(x => x.Trim()).Distinct();

            bool routeMatch = true;
            if (!routeParam.Equals(Activator.CreateInstance(routeParam.GetType())))
                routeMatch = (routeData.Values[routeParam.Key] != null && routeData.Values[routeParam.Key].ToString() == routeParam.Value);

            return acceptedActions.Contains(currentAction) &&
                   acceptedControllers.Contains(currentController) &&
                   acceptedAreas.Contains(currentArea) &&
                   routeMatch ? activeClass : String.Empty;
        }
    }
}