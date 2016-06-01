using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace sidekick
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class FileUploadAttribute : ValidationAttribute
    {
        public FileType[] AcceptedFileExtensions { get; set; }
        public bool Required { get; set; }

        public FileUploadAttribute(bool required, params FileType[] fileTypes)
        {
            Required = required;
            AcceptedFileExtensions = fileTypes;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            HttpPostedFileBase upload = value as HttpPostedFileBase;
            if (upload == null)
            {
                if (Required)
                    return new ValidationResult("Please select a file to upload!");

                return ValidationResult.Success;
            }

            if (!AcceptedFileExtensions.Any(x => x.GetAttribute<ExtensionAttribute>().Extension == upload.FileName.GetFileExtention()))
                return new ValidationResult(String.Format("Template file must be in one of these formats: {0}", String.Join(", ", AcceptedFileExtensions.Select(x => x))));

            return ValidationResult.Success;
        }
    }
}