using System;
using System.ComponentModel.DataAnnotations;

namespace sidekick
{
    /// <summary>
    ///     Validates a DateTime property to ensure that the date selected is not after the current date and time.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class NoFutureDateAttribute : ValidationAttribute
    {
        public NoFutureDateAttribute()
            : base("Date cannot be a future date")
        {
        }

        public NoFutureDateAttribute(string errorMessage)
            : base(errorMessage)
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            DateTime date = Convert.ToDateTime(value);
            return date > DateTime.Now ?
                   new ValidationResult(ErrorMessage, new[] { validationContext.MemberName }) :
                   ValidationResult.Success;
        }
    }
}
