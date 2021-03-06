﻿using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace sidekick
{
    /// <summary>
    ///     Validate a string for make sure that it is free of specific characters
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class ExcludeCharAttribute : ValidationAttribute
    {
        private readonly string[] _excludedChars;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="excludedChars">String of characters to exclude.</param>
        public ExcludeCharAttribute(params string[] excludedChars)
            : base("{0} contains an invalid character")
        {
            _excludedChars = excludedChars;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            string stringValue = value.ToString();
            foreach (string excludedChar in _excludedChars)
            {
                if (stringValue.Contains(excludedChar))
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName), new[] { validationContext.MemberName });
            }

            return ValidationResult.Success;
        }
    }
}