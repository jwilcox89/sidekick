using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace sidekick
{
    public static class Extentions
    {
        /// <summary>
        ///     Converts an object to an int
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static int ToInt<T>(this T item) {
            return Convert.ToInt32(item);
        }

        /// <summary>
        ///     Converts an object to a short
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static short ToShort<T>(this T item) {
            return Convert.ToInt16(item);
        }

        /// <summary>
        ///     Formats a string into the 555-555-5555 format.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetReadablePhoneNumber(this string input) {
            if (string.IsNullOrEmpty(input))
                return null;

            return Regex.Replace(input, @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3");
        }

        /// <summary>
        ///     Takes the 555-555-5555 format and turns it into a simple string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetDigits(this string input) {
            if (string.IsNullOrEmpty(input))
                return null;

            return Regex.Replace(input, @"[^\d]+", string.Empty);
        }

        /// <summary>
        ///     Checks if the sting input has a value and is a valid number
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsValidNumber(this string input) {
            return !string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^\d+$");
        }

        /// <summary>
        ///     Makes list of enums.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> GetEnumValues<T>() {
            if (typeof(T).BaseType != typeof(Enum))
                throw new ArgumentException("Must be a type of System.Enum");

            return (T[])Enum.GetValues(typeof(T));
        }
    }
}
