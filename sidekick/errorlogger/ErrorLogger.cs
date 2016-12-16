using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Data.Entity;
using System.Runtime.InteropServices;

namespace sidekick
{
    /// <summary>
    ///     Error logger to be used with MVC exceptions and standard exceptions. Logs error in to a database table.
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public class ErrorLogger<TContext> : BaseRepo<TContext>
        where TContext : DbContext, new()
    {
        /// <summary>
        ///     Logs the error using the ExceptionContext data provided.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="ex"></param>
        public void LogError<TEntity>(ExceptionContext ex, string comments = null)
            where TEntity : class, IErrorLog, new()
        {
            Add(new TEntity
            {
                Time = DateTime.Now,
                Exception = ex.GetExceptionMessage(),
                InnerException = ex.GetInnerExceptionMessage(),
                StackTrace = ex.GetStackTraceMessage(),
                User = Thread.CurrentPrincipal.Identity.Name,
                Route = ex.GetRoute(),
                Query = ex.GetQuery(),
                Comments = comments
            }).Save();
        }

        /// <summary>
        ///     Logs the error using the Exception data provided.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="ex"></param>
        /// <param name="route"></param>
        public void LogError<TEntity>(_Exception ex, string comments = null)
            where TEntity : class, IErrorLog, new()
        {
            Add(new TEntity
            {
                Time = DateTime.Now,
                Exception = ex.GetExceptionMessage(),
                InnerException = ex.GetInnerExceptionMessage(),
                StackTrace = ex.GetStackTraceMessage(),
                Comments = comments
            }).Save();
        }

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
        ///     Clears out all the log entries.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        public void ClearLogs<TEntity>()
            where TEntity : class, IErrorLog
        {
            Remove<TEntity>(GetAll<TEntity>()).Save();
        }
    }
}