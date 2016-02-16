using System;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace sidekick
{
    public class JsonErrorResult : JsonResult
    {
        private string _viewName;

        /// <summary>
        ///     Returns a JSON object with the current model state errors
        ///     
        ///     Object Details:
        ///     Success = false
        ///     view = "_AjaxMessage"
        /// </summary>
        public JsonErrorResult()
        {
        }

        /// <summary>
        ///     Returns a JSON object with the current model state errors
        ///     
        ///     Object Details:
        ///     Success = false
        ///     view = "viewName parameter"
        /// </summary>
        /// <param name="viewName">Name of the Razor view that holds the error</param>
        public JsonErrorResult(string viewName)
        {
            _viewName = viewName;
        }

        /// <summary>
        ///     Returns a JSON object with the current model state errors
        ///     
        ///     Object Details:
        ///     Success = false
        ///     view = "_AjaxMessage"
        /// </summary>
        /// <param name="behavior"></param>
        public JsonErrorResult(JsonRequestBehavior behavior)
        {
            JsonRequestBehavior = behavior;
        }

        /// <summary>
        ///     Returns a JSON object with the current model state errors
        ///     
        ///     Object Details:
        ///     Success = false
        ///     view = "viewName parameter"
        /// </summary>
        /// <param name="viewName">Name of the Razor view that holds the error</param>
        /// <param name="behavior"></param>
        public JsonErrorResult(string viewName, JsonRequestBehavior behavior)
        {
            _viewName = viewName;
            JsonRequestBehavior = behavior;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = !String.IsNullOrEmpty(ContentType) ? ContentType : "application/json";

            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;

            response.Write(JsonConvert.SerializeObject(new
            {
                success = false,
                view = (String.IsNullOrEmpty(_viewName) ? ElementBuilder.BuildAlert<Alert>(context.Controller.ViewData.ModelState) : ElementBuilder.BuildAlert<Alert>(context.Controller.ViewData.ModelState, _viewName))
            }));
        }
    }
}
