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
    public static class NavUtils
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="controllers"></param>
        /// <returns></returns>
        public static string IsActiveNavItem(this HtmlHelper helper, string[] controllers)
        {
            return IsActiveNavItem(helper, controllers, null, null, new KeyValuePair<string, string>(), null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="controllers"></param>
        /// <param name="actions"></param>
        /// <returns></returns>
        public static string IsActiveNavItem(this HtmlHelper helper, string[] controllers, string[] actions)
        {
            return IsActiveNavItem(helper, controllers, actions, null, new KeyValuePair<string, string>(), null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="controllers"></param>
        /// <param name="actions"></param>
        /// <param name="areas"></param>
        /// <returns></returns>
        public static string IsActiveNavItem(this HtmlHelper helper, string[] controllers, string[] actions, string[] areas)
        {
            return IsActiveNavItem(helper, controllers, actions, areas, new KeyValuePair<string, string>(), null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="controllers"></param>
        /// <param name="actions"></param>
        /// <param name="areas"></param>
        /// <param name="routeParam"><para>Key: Part of route that you wish to match the value with</para>
        /// <para>Value: value that you want to check the key for</para>
        /// </param>
        /// <returns></returns>
        public static string IsActiveNavItem(this HtmlHelper helper, string[] controllers, string[] actions, string[] areas, KeyValuePair<string, string> routeParam)
        {
            return IsActiveNavItem(helper, controllers, actions, areas, routeParam, null, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="controllers"></param>
        /// <param name="actions"></param>
        /// <param name="areas"></param>
        /// <param name="routeParam"><para>Key: Part of route that you wish to match the value with</para>
        /// <para>Value: value that you want to check the key for</para></param>
        /// <param name="activeClass"></param>
        /// <returns></returns>
        public static string IsActiveNavItem(this HtmlHelper helper, string[] controllers, string[] actions, string[] areas, KeyValuePair<string, string> routeParam, string activeClass)
        {
            return IsActiveNavItem(helper, controllers, actions, areas, routeParam, activeClass, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="controllers"></param>
        /// <param name="actions"></param>
        /// <param name="areas"></param>
        /// <param name="routeParam"><para>Key: Part of route that you wish to match the value with</para>
        /// <para>Value: value that you want to check the key for</para></param>
        /// <param name="activeClass"></param>
        /// <param name="inactiveClass"></param>
        /// <returns></returns>
        public static string IsActiveNavItem(this HtmlHelper helper, string[] controllers, string[] actions, string[] areas, KeyValuePair<string, string> routeParam, string activeClass, string inactiveClass)
        {
            activeClass = (String.IsNullOrEmpty(activeClass)) ? "active" : activeClass;
            inactiveClass = (String.IsNullOrEmpty(inactiveClass)) ? String.Empty : inactiveClass;
            RouteData routeData = helper.ViewContext.RouteData;
            string currentAction = (string)routeData.Values["action"];
            string currentController = (string)routeData.Values["controller"];
            string currentArea = (string)routeData.DataTokens["area"];

            if (!currentArea.Any())
                currentArea = String.Empty;

            actions = actions == null ? new[] { currentAction } : actions;
            controllers = controllers == null ? new[] { currentController } : controllers;
            areas = areas == null ? new[] { currentArea } : areas;

            if (actions == null)
                actions = new[] { "" };

            if (controllers == null)
                controllers = new[] { "" };

            if (areas == null)
                areas = new[] { "" };

            IEnumerable<string> acceptedActions = actions.Select(x => x.Trim()).Distinct();
            IEnumerable<string> acceptedControllers = controllers.Select(x => x.Trim()).Distinct();
            IEnumerable<string> acceptedAreas = areas.Select(x => x.Trim()).Distinct();

            bool routeMatch = true;
            if (!routeParam.Equals(Activator.CreateInstance(routeParam.GetType())))
                routeMatch = (routeData.Values[routeParam.Key] != null && routeData.Values[routeParam.Key].ToString() == routeParam.Value);

            return acceptedActions.Contains(currentAction) &&
                   acceptedControllers.Contains(currentController) &&
                   acceptedAreas.Contains(currentArea) &&
                   routeMatch ? activeClass : inactiveClass;
        }
    }
}