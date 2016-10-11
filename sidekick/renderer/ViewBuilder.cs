using System;
using System.Web.Mvc;
using System.Web;
using System.Web.Routing;
using System.IO;
using System.Reflection;

namespace sidekick
{
    public class ViewBuilder : ControllerBase, IDisposable
    {
        public HttpContextBase CurrentHttpContext { get; set; }

        public ViewBuilder()
        {
            if (HttpContext.Current != null)
                CurrentHttpContext = new HttpContextWrapper(HttpContext.Current);
        }

        protected override void ExecuteCore()
        {
        }

        /// <summary>
        ///     Returns a string of the HTML for a view
        /// </summary>
        /// <param name="viewName">View name</param>
        /// <returns></returns>
        public string RenderView(string viewName)
        {
            return BuildView(viewName, null, null);
        }

        /// <summary>
        ///     Returns a string of the HTML for a view
        /// </summary>
        /// <param name="viewName">View name</param>
        /// <param name="model">Object model that the view uses</param>
        /// <returns></returns>
        public string RenderView(string viewName, object model)
        {
            return BuildView(viewName, model, null);
        }

        /// <summary>
        ///     Returns a string of the HTML for a view
        /// </summary>
        /// <param name="viewName">View name</param>
        /// <param name="model">Object model that the view uses</param>
        /// <param name="tempData">Temp data to be used in the view</param>
        /// <returns></returns>
        public string RenderView(string viewName, object model, object tempData)
        {
            return BuildView(viewName, model, tempData);
        }

        /// <summary>
        ///     Builds the view and returns a string of the HTML of the view
        /// </summary>
        /// <param name="viewName">View name</param>
        /// <param name="model">Object model that the view uses</param>
        /// <param name="additionalTempData">Temp data to be used in the view</param>
        /// <returns></returns>
        private string BuildView(string viewName, object model, object additionalTempData)
        {
            if (ControllerContext == null)
                CreateControllerContext();

            if (model != null)
                ViewData.Model = model;

            if (additionalTempData != null)
            {
                foreach (PropertyInfo p in additionalTempData.GetType().GetProperties())
                {
                    if (TempData.ContainsKey(p.Name))
                        TempData.Remove(p.Name);

                    TempData.Add(p.Name, p.GetValue(additionalTempData, null));
                }
            }

            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);

                viewResult.View.Render(viewContext, sw);
                return sw.GetStringBuilder().ToString();
            }
        }

        private void CreateControllerContext()
        {
            if (CurrentHttpContext == null)
                throw new ArgumentNullException("CurrentHttpContext", "CurrentHttpContext cannot be null");

            RouteData routeData = RouteTable.Routes.GetRouteData(CurrentHttpContext);
            ControllerContext = new ControllerContext(CurrentHttpContext, routeData, this);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
