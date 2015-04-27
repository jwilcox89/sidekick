using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace sidekick
{
    public static class ValidationExtensions
    {
        /// <summary>
        ///     Checks if the sting input has a value and is a valid number
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsValidNumber(this string input) {
            return !string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^\d+$");
        }

        /// <summary>
        ///     Returns the last 4 characters of a string (.pdf, .doc etc)
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string GetFileExtention(this string text) {
            return Path.GetExtension(text).ToLower();
        }

        /// <summary>
        ///     If the string is null then the value is set to an empty ("") string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SetEmptyIfNull(this string value) {
            return (value == null) ? string.Empty : value;
        }
    }
}
