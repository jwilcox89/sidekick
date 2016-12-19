using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace sidekick
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class FileUploadAttribute : ValidationAttribute
    {
        public string[] AcceptedFileExtensions { get; set; }
        public bool Required { get; set; }

        public FileUploadAttribute(bool required, params string[] acceptedExtensions)
        {
            Required = required;
            AcceptedFileExtensions = acceptedExtensions;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            HttpPostedFileBase upload = value as HttpPostedFileBase;
            if (upload == null)
            {
                if (Required)
                    return new ValidationResult("Please select a file to upload!", new[] { validationContext.MemberName });

                return ValidationResult.Success;
            }

            if (!AcceptedFileExtensions.Any(x => x == upload.FileName.GetFileExtention()))
                return new ValidationResult($"File must be in one of these formats: {String.Join(", ", AcceptedFileExtensions.Select(x => x))}", new[] { validationContext.MemberName });

            return ValidationResult.Success;
        }
    }
}