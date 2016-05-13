using System;
using System.Web.Mvc;
using System.Runtime.InteropServices;

namespace sidekick
{
    /// <summary>
    ///     Extensions that grab data from exceptions
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        ///     Returns the exception or a null string
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetExceptionMessage(this ExceptionContext ex) 
        {
            if (ex != null && ex.Exception != null)
                return ex.Exception.Message;

            return String.Empty;
        }

        /// <summary>
        ///     Returns the exception or a null string
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetExceptionMessage(this _Exception ex) 
        {
            if (ex != null)
                return ex.Message;

            return String.Empty;
        }

        /// <summary>
        ///     Returns the inner exception message or a null string
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetInnerExceptionMessage(this ExceptionContext ex) 
        {
            if (ex != null && ex.Exception != null && ex.Exception.InnerException != null) 
            {

                if (!String.IsNullOrEmpty(ex.Exception.InnerException.Message))
                    return ex.Exception.InnerException.Message;

                Exception originalException = ex.Exception.InnerException.GetBaseException();

                if (originalException.InnerException != null)
                    return originalException.InnerException.Message;
            }

            return String.Empty;
        }

        /// <summary>
        ///     Returns the inner exception message or a null string
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetInnerExceptionMessage(this _Exception ex) 
        {
            if (ex != null && ex.InnerException != null) 
            {

                if (!String.IsNullOrEmpty(ex.InnerException.Message))
                    return ex.InnerException.Message;

                Exception originalException = ex.InnerException.GetBaseException();

                if (originalException.InnerException != null)
                    return originalException.InnerException.Message;
            }

            return String.Empty;
        }

        /// <summary>
        ///     Returns the stack trace message or a null string
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetStackTraceMessage(this ExceptionContext ex) 
        {
            if (ex != null && ex.Exception != null && !String.IsNullOrEmpty(ex.Exception.StackTrace))
                return ex.Exception.StackTrace;

            return String.Empty;
        }

        /// <summary>
        ///     Returns the stack trace message or a null string
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetStackTraceMessage(this _Exception ex) 
        {
            if (ex != null && !String.IsNullOrEmpty(ex.StackTrace))
                return ex.StackTrace;

            return String.Empty;
        }

        /// <summary>
        ///     Returns the route
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetRoute(this ExceptionContext ex) 
        {
            if (ex != null && ex.RequestContext != null && ex.RequestContext.RouteData != null) 
            {
                string route = String.Join(", ", ex.RequestContext.RouteData.Values);
                return !String.IsNullOrEmpty(route) ? route : String.Empty;
            }

            return String.Empty;
        }

        /// <summary>
        ///     Returns the query associated with the route
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetQuery(this ExceptionContext ex) 
        {
            if (ex != null && ex.RequestContext != null && ex.RequestContext.HttpContext != null && ex.RequestContext.HttpContext.Request != null) 
            {
                string query = String.Join(", ", ex.RequestContext.HttpContext.Request.QueryString);
                return !String.IsNullOrEmpty(query) ? query : String.Empty;
            }

            return String.Empty;
        }
    }
}
