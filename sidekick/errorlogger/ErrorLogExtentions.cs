using System;
using System.Web.Mvc;

namespace sidekick
{
    public static class ErrorLogExtentions
    {
        /// <summary>
        ///     Returns the exception or a null string
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetExceptionMessage(this ExceptionContext ex) {
            if (ex != null && ex.Exception != null)
                return ex.Exception.Message;

            return string.Empty;
        }

        /// <summary>
        ///     Returns the inner exception message or a null string
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetInnerExceptionMessage(this ExceptionContext ex) {
            if (ex != null && ex.Exception != null && ex.Exception.InnerException != null) {

                if (!string.IsNullOrEmpty(ex.Exception.InnerException.Message))
                    return ex.Exception.InnerException.Message;

                Exception originalException = ex.Exception.InnerException.GetBaseException();

                if (originalException.InnerException != null)
                    return originalException.InnerException.Message;
            }

            return string.Empty;
        }

        /// <summary>
        ///     Returns the stack trace message or a null string
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetStackTraceMessage(this ExceptionContext ex) {
            if (ex != null && ex.Exception != null && !string.IsNullOrEmpty(ex.Exception.StackTrace))
                return ex.Exception.StackTrace;

            return string.Empty;
        }

        /// <summary>
        ///     Returns the route
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetRoute(this ExceptionContext ex) {
            if (ex != null && ex.RequestContext != null && ex.RequestContext.RouteData != null) {
                string route = string.Join(", ", ex.RequestContext.RouteData.Values);
                return !string.IsNullOrEmpty(route) ? route : string.Empty;
            }

            return string.Empty;
        }

        /// <summary>
        ///     Returns the query associated with the route
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetQuery(this ExceptionContext ex) {
            if (ex != null && ex.RequestContext != null && ex.RequestContext.HttpContext != null && ex.RequestContext.HttpContext.Request != null) {
                string query = string.Join(", ", ex.RequestContext.HttpContext.Request.QueryString);
                return !string.IsNullOrEmpty(query) ? query : string.Empty;
            }

            return string.Empty;
        }
    }
}
