using System;
using System.ComponentModel.DataAnnotations;

namespace sidekick
{
    /// <summary>
    ///     Validates a DateTime property to ensure that the date selected is not before the current date and time.
    /// </summary>
    public class NoPastDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) 
        {
            if (value == null)
                return ValidationResult.Success;

            DateTime date = Convert.ToDateTime(value);
            if (date < DateTime.Now)
                return new ValidationResult("Date cannot be a past date");

            return ValidationResult.Success;
        }
    }
}
