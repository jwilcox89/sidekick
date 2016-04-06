using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;

namespace sidekick
{
    public class RepoException : Exception
    {
        public IEnumerable<DbEntityValidationResult> ValidationErrors { get; set; }

        public RepoException(Exception ex, IEnumerable<DbEntityValidationResult> validationErrors)
            : base("An error has occured when trying to save.", ex)
        {
            ValidationErrors = validationErrors;
        }
    }
}
