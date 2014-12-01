using System;
using System.Web.Mvc;
using System.Web;
using System.Web.Routing;
using System.IO;

namespace sidekick
{
    public class ViewBuilder : ControllerBase
    {
        public HttpContextBase CurrentHttpContext { get; set; }

        public ViewBuilder() {
            if (HttpContext.Current != null)
                CurrentHttpContext = new HttpContextWrapper(HttpContext.Current);
        }

        protected override void ExecuteCore() {
        }

        public string RenderView(string viewName, object model, object additionalTempData = null) {

            if (ControllerContext == null)
                CreateControllerContext();

            ViewData.Model = model;

            if (additionalTempData != null) {
                foreach( var p in additionalTempData.GetType().GetProperties()) {
                    if (TempData.ContainsKey(p.Name))
                        TempData.Remove(p.Name);

                    TempData.Add(p.Name, p.GetValue(additionalTempData, null));
                }
            }

            using (var sw = new StringWriter()) {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);

                viewResult.View.Render(viewContext, sw);
                return sw.GetStringBuilder().ToString();
            }
        }

        private void CreateControllerContext() {

            if (CurrentHttpContext == null)
                throw new ArgumentNullException("CurrentHttpContext", "CurrentHttpContext cannot be null");

            var routeData = RouteTable.Routes.GetRouteData(CurrentHttpContext);
            ControllerContext = new ControllerContext(CurrentHttpContext, routeData, this);
        }
    }
}
