using System;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace sidekick
{
    /// <summary>
    ///     Validate the size of an uploaded document, photo, video etc.
    /// </summary>
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;

        /// <summary>
        ///     Validates the file's size is no bigger than 512 MB
        /// </summary>
        public MaxFileSizeAttribute()
        {
            _maxFileSize = 1024 * 1024 * 500;
        }

        /// <summary>
        ///     Validates the file's size is no bigger than the size specified.
        /// </summary>
        /// <param name="maxFileSize"></param>
        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            HttpPostedFileBase file = value as HttpPostedFileBase;
            if (file.ContentLength > _maxFileSize)
                return new ValidationResult(String.Format("The file you selected is too large. Maximum allowed size is {0} MB", (_maxFileSize / 1024).ToString()));

            return ValidationResult.Success;
        }
    }
}
