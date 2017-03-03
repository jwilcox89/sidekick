using System;
using System.Web.Mvc;
using System.Runtime.InteropServices;

namespace sidekick
{
    /// <summary>
    ///     Extensions that grab data from exceptions
    /// </summary>
    public static class ExceptionUtils
    {
        /// <summary>
        ///     Get browser name and version that error occured on
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetBrowserInfo(this ExceptionContext context)
        {
            return context?.RequestContext?.HttpContext?.Request?.Browser?.Type;
        }

        /// <summary>
        ///     Returns the exception or a null string
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetExceptionMessage(this ExceptionContext context)
        {
            return context?.Exception?.Message;
        }

        /// <summary>
        ///     Returns the exception or a null string
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static string GetExceptionMessage(this _Exception exception)
        {
            return exception?.Message;
        }

        /// <summary>
        ///     Returns the inner exception message or a null string
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetInnerExceptionMessage(this ExceptionContext context)
        {
            return context?.Exception?.InnerException?.Message;
        }

        /// <summary>
        ///     Returns the inner exception message or a null string
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static string GetInnerExceptionMessage(this _Exception exception)
        {
            return exception?.InnerException.Message;
        }

        /// <summary>
        ///     Returns the stack trace message or a null string
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetStackTraceMessage(this ExceptionContext context)
        {
            return context?.Exception?.StackTrace;
        }

        /// <summary>
        ///     Returns the stack trace message or a null string
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static string GetStackTraceMessage(this _Exception exception)
        {
            return exception?.StackTrace;
        }

        /// <summary>
        ///     Returns the route
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetRoute(this ExceptionContext context)
        {
            string route = String.Join(", ", context?.RequestContext?.RouteData?.Values);
            return !String.IsNullOrWhiteSpace(route) ? route : null;
        }

        /// <summary>
        ///     Returns the query associated with the route
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetQuery(this ExceptionContext context)
        {
            string query = String.Join(", ", context?.RequestContext?.HttpContext?.Request?.QueryString);
            return !String.IsNullOrWhiteSpace(query) ? query : null;
        }
    }
}
