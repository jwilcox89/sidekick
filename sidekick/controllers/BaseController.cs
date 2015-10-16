using System;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace sidekick
{
    public class BaseController : Controller
    {
        private TempDataManager _tempMgr;

        /// <summary>
        ///     Helps manage the temp data
        /// </summary>
        protected TempDataManager TempMgr {
            get {
                return _tempMgr = _tempMgr ?? new TempDataManager(TempData);
            }
        }

        /// <summary>
        ///     Returns a Json Error 
        /// </summary>
        /// <returns></returns>
        protected virtual JsonResult JsonError() {
            return new JsonErrorResult();
        }

        /// <summary>
        ///     Returns a Json Error 
        /// </summary>
        /// <param name="viewName"></param>
        /// <returns></returns>
        protected virtual JsonResult JsonError(string viewName) {
            return new JsonErrorResult(viewName);
        }

        /// <summary>
        ///     Returns a Json Error
        /// </summary>
        /// <param name="behavior"></param>
        /// <returns></returns>
        protected virtual JsonResult JsonError(JsonRequestBehavior behavior) {
            return new JsonErrorResult(behavior);
        }

        /// <summary>
        ///     Returns a Json Error 
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="behavior"></param>
        /// <returns></returns>
        protected virtual JsonResult JsonError(string viewName, JsonRequestBehavior behavior) {
            return new JsonErrorResult(viewName, behavior);
        }
    }
}
