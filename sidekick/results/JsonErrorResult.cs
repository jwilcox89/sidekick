using System.Web.Mvc;
using System.Web;
using Newtonsoft.Json;

namespace sidekick
{
    public class JsonErrorResult : JsonResult
    {
        /// <summary>
        ///     Returns a JSON object with success = false and view = an alert with the current model state errors
        /// </summary>
        public JsonErrorResult() {}

        public override void ExecuteResult(ControllerContext context) {
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = !string.IsNullOrEmpty(ContentType) ? ContentType : "application/json";

            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;

            response.Write(JsonConvert.SerializeObject(new { success = false, view = Builder.BuildAlert<Alert>(context.Controller.ViewData.ModelState) }));
        }
    }
}
