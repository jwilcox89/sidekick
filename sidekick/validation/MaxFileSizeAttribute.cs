using System;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sidekick
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple=false, Inherited=false)]
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;
        
        /// <summary>
        ///     Validates the file's size is no bigger than 1024 * 1024 * 500
        /// </summary>
        public MaxFileSizeAttribute() {
            _maxFileSize = 1024 * 1024 * 500;
        }

        /// <summary>
        ///     Validates the file's size is no bigger than the size specified.
        /// </summary>
        /// <param name="maxFileSize"></param>
        public MaxFileSizeAttribute(int maxFileSize) {
            _maxFileSize = maxFileSize;
        }

        public override bool IsValid(object value) {

            var file = value as HttpPostedFileBase;

            if (file != null && file.ContentLength > _maxFileSize) {
                ErrorMessage = string.Format("The file you selected is too large. Maximum allowed size is {0} MB", (_maxFileSize / 1024).ToString());
                return false;
            }

            return true;
        }
    }

}
