using System;
using System.Threading;
using System.Web.Mvc;
using System.Data.Entity;
using System.Runtime.InteropServices;

namespace sidekick
{
    /// <summary>
    ///     Exception logger
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public class ErrorLogger<TContext> : BaseRepo<TContext>
        where TContext : DbContext, new()
    {
        /// <summary>
        ///     Logs the error using the data the user has provided.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="action"></param>
        public void LogError<TEntity>(TEntity error)
            where TEntity : class, IErrorLog
        {
            Add(error).Save();
        }

        /// <summary>
        ///     Logs the error using the ExceptionContext data provided.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="exception"></param>
        /// <param name="comments"></param>
        public void LogError<TEntity>(ExceptionContext exception, string comments = null)
            where TEntity : class, IErrorLog, new()
        {
            Add(new TEntity
            {
                Time = DateTime.Now,
                Exception = exception.GetExceptionMessage(),
                InnerException = exception.GetInnerExceptionMessage(),
                StackTrace = exception.GetStackTraceMessage(),
                User = Thread.CurrentPrincipal.Identity.Name,
                Route = exception.GetRoute(),
                Query = exception.GetQuery(),
                Comments = comments
            }).Save();
        }

        /// <summary>
        ///     Logs the error using the Exception data provided.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="exception"></param>
        /// <param name="route"></param>
        /// <param name="comments"></param>
        public void LogError<TEntity>(_Exception exception, string comments = null)
            where TEntity : class, IErrorLog, new()
        {
            Add(new TEntity
            {
                Time = DateTime.Now,
                Exception = exception.GetExceptionMessage(),
                InnerException = exception.GetInnerExceptionMessage(),
                StackTrace = exception.GetStackTraceMessage(),
                Comments = comments
            }).Save();
        }
    }
}