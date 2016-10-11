using System;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace sidekick
{
    /// <summary>
    ///     Validate the size of an uploaded document, photo, video etc.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
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
        ///     Validates the file's size is no bigger than the size specified in MBs.
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
            return file.ContentLength > _maxFileSize ?
                   new ValidationResult($"The file you selected is too large. Maximum allowed size is {(_maxFileSize / 1024).ToString()} MB", new[] { validationContext.MemberName }) :
                   ValidationResult.Success;
        }
    }
}
