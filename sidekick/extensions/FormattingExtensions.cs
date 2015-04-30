using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace sidekick
{
    public static class FormattingExtensions
    {
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

        #region Currency

        /// <summary>
        ///     Formats decimal into currency
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static string FormatCurrency(this HtmlHelper helper, decimal? amount) {
            if (amount.HasValue)
                return amount.Value.ToString("C");

            return string.Empty;
        }

        /// <summary>
        ///     Formats decimal into currency
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static string FormatCurrency(this decimal? amount) {
            if (amount.HasValue)
                return amount.Value.ToString("C");

            return string.Empty;
        }

        /// <summary>
        ///     Formats decimal into currency
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static string FormatCurrency(this HtmlHelper hlper, decimal amount) {
            return amount.ToString("C");
        }

        /// <summary>
        ///     Formats decimal into currency
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static string FormatCurrency(this decimal amount) {
            return amount.ToString("C");
        }

        /// <summary>
        ///     Formats int into currency
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static string FormatCurrency(this HtmlHelper helper, int? amount) {
            if (amount.HasValue)
                return amount.Value.ToString("C");

            return string.Empty;
        }

        /// <summary>
        ///     Formats int into currency
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static string FormatCurrency(this int? amount) {
            if (amount.HasValue)
                return amount.Value.ToString("C");

            return string.Empty;
        }

        /// <summary>
        ///     Formats int into currency
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static string FormatCurrency(this HtmlHelper helper, int amount) {
            return amount.ToString("C");
        }

        /// <summary>
        ///     Formats int into currency
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static string FormatCurrency(this int amount) {
            return amount.ToString("C");
        }

        #endregion

        #region Phone Number

        /// <summary>
        ///     Formats a string into a phone number
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="number"></param>
        /// <param name="areaCodeParens"></param>
        /// <returns></returns>
        public static string FormatPhone(this HtmlHelper helper, string number, bool areaCodeParens = true) {
            if (string.IsNullOrEmpty(number))
                return string.Empty;

            if (number.Trim().Length < 10) {
                return Regex.Replace(number, "(\\d{3})(\\d{4})", "$1-$2");
            } else {
                if (areaCodeParens) {
                    return Regex.Replace(number, "(\\d{3})(\\d{3})(\\d{4})", "($1) $2-$3");
                } else {
                    return Regex.Replace(number, "(\\d{3})(\\d{3})(\\d{4})", "$1-$2-$3");
                }
            }
        }

        /// <summary>
        ///     Formats a string into a phone number
        /// </summary>
        /// <param name="number"></param>
        /// <param name="areaCodeParens"></param>
        /// <returns></returns>
        public static string FormatPhone(this string number, bool areaCodeParens = true) {
            if (string.IsNullOrEmpty(number))
                return string.Empty;

            if (number.Trim().Length < 10) {
                return Regex.Replace(number, "(\\d{3})(\\d{4})", "$1-$2");
            } else {
                if (areaCodeParens) {
                    return Regex.Replace(number, "(\\d{3})(\\d{3})(\\d{4})", "($1) $2-$3");
                } else {
                    return Regex.Replace(number, "(\\d{3})(\\d{3})(\\d{4})", "$1-$2-$3");
                }
            }
        }

        #endregion

        #region SSN

        /// <summary>
        ///     Formats a string into a readable SSN
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="ssn"></param>
        /// <returns></returns>
        public static string FormatSSN(this HtmlHelper helper, string ssn) {
            if (string.IsNullOrEmpty(ssn))
                return string.Empty;

            return ssn.Insert(3,"-").Insert(6,"-");
        }

        /// <summary>
        ///     Formats a string into a readable SSN
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="ssn"></param>
        /// <returns></returns>
        public static string FormatSSN(this string ssn) {
            if (string.IsNullOrEmpty(ssn))
                return string.Empty;

            return ssn.Insert(3,"-").Insert(6,"-");
        }

        #endregion
    }
}
