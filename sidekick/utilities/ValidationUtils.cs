﻿using System;
using System.Text.RegularExpressions;
using System.IO;

namespace sidekick
{
    /// <summary>
    ///     General validation extensions
    /// </summary>
    public static class ValidationUtils
    {
        /// <summary>
        ///     Checks if the sting input has a value and is a valid number
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsValidNumber(this string input) 
        {
            return !String.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^\d+$");
        }

        /// <summary>
        ///     Returns the file extension for the provided path
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string GetFileExtention(this string text) 
        {
            return Path.GetExtension(text).ToLower();
        }

        /// <summary>
        ///     If the string is null then the value is set to an empty ("") String.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SetEmptyIfNull(this string value) 
        {
            return (value == null) ? String.Empty : value;
        }
    }
}
