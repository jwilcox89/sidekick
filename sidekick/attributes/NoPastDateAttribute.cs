using System;
using System.ComponentModel.DataAnnotations;

namespace sidekick
{
    /// <summary>
    ///     Validates a DateTime property to ensure that the date selected is not before the current date and time.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class NoPastDateAttribute : ValidationAttribute
    {
        public NoPastDateAttribute()
            : base("Date cannot be a past date")
        { }

        public NoPastDateAttribute(string errorMessage)
            : base(errorMessage)
        { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            DateTime date = Convert.ToDateTime(value);
            return date < DateTime.Now ?
                   new ValidationResult(ErrorMessage, new[] { validationContext.MemberName }) :
                   ValidationResult.Success;
        }
    }
}
