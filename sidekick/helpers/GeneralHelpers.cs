using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace sidekick
{
    public static class GeneralHelpers
    {
        /// <summary>
        ///     Returns the "active" class name or an empty string depending on the criteria 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="actions">String of actions separated by a ','</param>
        /// <param name="controllers">String of controller names separated by a ','</param>
        /// <param name="areas">String of area names separated by a ','</param>
        /// <param name="activeClass">The name of the "active" class. Default value is "active"</param>
        /// <returns></returns>
        public static string IsActiveNavItem(this HtmlHelper helper, string actions, string controllers, string areas = null, string activeClass = null) 
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

            return acceptedActions.Contains(currentAction) &&
                   acceptedControllers.Contains(currentController) &&
                   acceptedAreas.Contains(currentArea) ? activeClass : String.Empty;
        }
    }
}
