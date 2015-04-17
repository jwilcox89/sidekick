using System;
using System.Runtime.InteropServices;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace sidekick
{
    public class RepositoryException : Exception
    {
        public string ExceptionMessage      { get; set; }
        public string InnerExceptionDetails { get; set; }
        public string ExceptionType         { get; set; }

        public RepositoryException(string errorMessage, Exception ex)
            : base(errorMessage) {

            if (ex is DbUpdateException) {
                ExceptionType = "DbUpdateException";
                SetException<DbUpdateException>((DbUpdateException)ex);
            } else if (ex is DbUpdateConcurrencyException) {
                ExceptionType = "DbUpdateConcurrencyException";
                SetException<DbUpdateConcurrencyException>((DbUpdateConcurrencyException)ex);
            } else if (ex is DbEntityValidationException) {
                ExceptionType = "DbUpdateConcurrencyException";
                SetException<DbEntityValidationException>((DbEntityValidationException)ex);
            } else {
                ExceptionType = "Unknown";
                SetException<Exception>(ex);
            }
        }

        private void SetException<E>(E ex) where E : _Exception {
            if (ex != null) {
                ExceptionMessage = ex.Message;
                if (ex.InnerException != null)
                    InnerExceptionDetails = ex.InnerException.ToString();
            }
        }
    }
}
