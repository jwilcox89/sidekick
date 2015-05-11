using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Data.Entity;
using System.Runtime.InteropServices;

namespace sidekick
{
    public static class ErrorLogger<TContext> where TContext : DbContext, new()
    {
        private static TContext DB = new TContext();

        /// <summary>
        ///     Logs the error using the ExceptionContext data provided.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="ex"></param>
        public static void LogError<TEntity>(ExceptionContext ex) where TEntity : class, IErrorLog, new() {
            TEntity error = new TEntity() { Time           = DateTime.Now,
                                            Exception      = ex.GetExceptionMessage(),
                                            InnerException = ex.GetInnerExceptionMessage(),
                                            StackTrace     = ex.GetStackTraceMessage(),
                                            User           = Thread.CurrentPrincipal.Identity.Name,
                                            Route          = ex.GetRoute(),
                                            Query          = ex.GetQuery() };

            DB.Set<TEntity>().Add(error);
            DB.SaveChanges();
        }

        /// <summary>
        ///     Logs the error using the Exception data provided.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="ex"></param>
        /// <param name="route"></param>
        public static void LogError<TEntity>(_Exception ex, string route) where TEntity : class, IErrorLog, new() {
            TEntity error = new TEntity() { Time           = DateTime.Now,
                                            Exception      = ex.GetExceptionMessage(),
                                            InnerException = ex.GetInnerExceptionMessage(),
                                            StackTrace     = ex.GetStackTraceMessage(),
                                            Route          = route };

            DB.Set<TEntity>().Add(error);
            DB.SaveChanges();
        }

        /// <summary>
        ///     Logs the error asynchronously using the ExceptionContext data provided.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static async Task LogErrorAsync<TEntity>(ExceptionContext ex) where TEntity : class, IErrorLog, new() {
            await Task.Run(() => LogError<TEntity>(ex));
        }

        /// <summary>
        ///     Logs the error asynchronously using the Exception data provided.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="ex"></param>
        /// <param name="route"></param>
        /// <returns></returns>
        public static async Task LogErrorAsync<TEntity>(_Exception ex, string route) where TEntity : class, IErrorLog, new() {
            await Task.Run(() => LogError<TEntity>(ex, route));
        }

        /// <summary>
        ///     Logs the error using the data the user has provided.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="action"></param>
        public static void LogError<TEntity>(Action<TEntity> action) where TEntity : class, IErrorLog, new() {
            TEntity error = new TEntity();
            action(error);

            DB.Set<TEntity>().Add(error);
            DB.SaveChanges();
        }

        /// <summary>
        ///     Logs the error asynchronously using the data the user has provided.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="action"></param>
        /// <returns></returns>
        public static async Task LogErrorAsync<TEntity>(Action<TEntity> action) where TEntity : class, IErrorLog, new() {
            await Task.Run(() => LogError<TEntity>(action));
        }

        /// <summary>
        ///     Clears out all the log entries.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        public static void ClearLogs<TEntity>() where TEntity : class, IErrorLog {
            DB.Set<TEntity>().RemoveRange(DB.Set<TEntity>());
            DB.SaveChanges();
        }

        /// <summary>
        ///     Asynchronously clears out all the log entries.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public static async Task ClearLogsAsync<TEntity>() where TEntity : class, IErrorLog {
            await Task.Run(() => ClearLogs<TEntity>());
        }
    }
}
