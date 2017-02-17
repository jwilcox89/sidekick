using System;
using System.Threading;
using System.Web.Mvc;
using System.Data.Entity;
using System.Runtime.InteropServices;

namespace sidekick
{
    /// <summary>
    ///     Error logger that creates new instance of DbContext so error can save without entity errors.
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public class ErrorLogger<TContext> : IDisposable
        where TContext : DbContext, new()
    {
        private TContext Context;

        public ErrorLogger()
        {
            Context = new TContext();
        }

        /// <summary>
        ///     Logs the error using the data the user has provided.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="action"></param>
        public void LogError<TEntity>(TEntity error)
            where TEntity : class, IErrorLog
        {
            Context.Set<TEntity>().Add(error);
            Context.SaveChanges();
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
            Context.Set<TEntity>().Add(new TEntity
            {
                Time = DateTime.Now,
                Exception = exception.GetExceptionMessage(),
                InnerException = exception.GetInnerExceptionMessage(),
                StackTrace = exception.GetStackTraceMessage(),
                User = Thread.CurrentPrincipal.Identity.Name,
                Route = exception.GetRoute(),
                Query = exception.GetQuery(),
                Comments = comments
            });

            Context.SaveChanges();
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
            Context.Set<TEntity>().Add(new TEntity
            {
                Time = DateTime.Now,
                Exception = exception.GetExceptionMessage(),
                InnerException = exception.GetInnerExceptionMessage(),
                StackTrace = exception.GetStackTraceMessage(),
                Comments = comments
            });

            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}