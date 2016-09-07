using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web;

namespace sidekick
{
    /// <summary>
    ///     Various extensions for formatting strings into currency, phone numbers, SSNs etc.
    /// </summary>
    public static class FormattingUtils
    {
        /// <summary>
        ///     ToShortDateString() and ToShortTimeString() extensions combined. If DateTime is null an empty string is returned.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToShortDateTimeString(this DateTime? date)
        {
            if (!date.HasValue)
                return String.Empty;

            return date.Value.ToShortDateTimeString();
        }

        /// <summary>
        ///     ToShortDateString() and ToShortTimeString() extensions combined.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToShortDateTimeString(this DateTime date)
        {
            return String.Format("{0} {1}", date.ToShortDateString(), date.ToShortTimeString());
        }

        /// <summary>
        ///     Insert text at the end of string. Always include a space between the original text and the text to append.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="toAppend"></param>
        /// <returns></returns>
        public static string Insert(this string original, string toAppend)
        {
            return Insert(original, toAppend, true);
        }

        /// <summary>
        ///     Insert text at the end of string.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="toAppend"></param>
        /// <param name="spaceBetween">True if you want a space between the original text and the text to append.</param>
        /// <returns></returns>
        public static string Insert(this string original, string toAppend, bool spaceBetween)
        {
            return original.Insert(original.Length, (spaceBetween) ? " " + toAppend : toAppend);
        }

        /// <summary>
        ///     Removes white space, '-' and ',' from string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ScrubForUrl(this string pTitle)
        {
            pTitle = pTitle.Replace(" ", "-");
            pTitle = HttpUtility.UrlEncode(pTitle);
            return Regex.Replace(pTitle, @"\%[0-9A-Fa-f]{2}", "");
        }

        /// <summary>
        ///     Takes the 555-555-5555 format and turns it into a simple string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetDigits(this string input) 
        {
            return String.IsNullOrEmpty(input) ? null : Regex.Replace(input, @"[^\d]+", String.Empty);
        }

        /// <summary>
        ///     Formats decimal into currency
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static string FormatCurrency(this HtmlHelper helper, decimal? amount) 
        {
            return amount.FormatCurrency();
        }

        /// <summary>
        ///     Formats decimal into currency
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static string FormatCurrency(this decimal? amount) 
        {
            return amount.HasValue ? amount.Value.ToString("C") : String.Empty;
        }

        /// <summary>
        ///     Formats decimal into currency
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static string FormatCurrency(this HtmlHelper helper, decimal amount) 
        {
            return amount.FormatCurrency();
        }

        /// <summary>
        ///     Formats decimal into currency
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static string FormatCurrency(this decimal amount) 
        {
            return amount.ToString("C");
        }

        /// <summary>
        ///     Formats int into currency
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static string FormatCurrency(this HtmlHelper helper, int? amount) 
        {
            return amount.FormatCurrency();
        }

        /// <summary>
        ///     Formats int into currency
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static string FormatCurrency(this int? amount) 
        {
            return amount.HasValue ? amount.Value.ToString("C") : String.Empty;
        }

        /// <summary>
        ///     Formats int into currency
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static string FormatCurrency(this HtmlHelper helper, int amount) 
        {
            return amount.FormatCurrency();
        }

        /// <summary>
        ///     Formats int into currency
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static string FormatCurrency(this int amount) 
        {
            return amount.ToString("C");
        }

        /// <summary>
        ///     Formats a string into a phone number
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="number"></param>
        /// <param name="areaCodeParens"></param>
        /// <returns></returns>
        public static string FormatPhone(this HtmlHelper helper, string number, bool areaCodeParens = true) 
        {
            return number.FormatPhone(areaCodeParens);
        }

        /// <summary>
        ///     Formats a string into a phone number
        /// </summary>
        /// <param name="number"></param>
        /// <param name="areaCodeParens"></param>
        /// <returns></returns>
        public static string FormatPhone(this string number, bool areaCodeParens = true) 
        {
            if (String.IsNullOrEmpty(number))
                return String.Empty;

            if (number.Trim().Length < 10) 
            {
                return Regex.Replace(number, "(\\d{3})(\\d{4})", "$1-$2");
            } 
            else 
            {
                return areaCodeParens ? Regex.Replace(number, "(\\d{3})(\\d{3})(\\d{4})", "($1) $2-$3") : Regex.Replace(number, "(\\d{3})(\\d{3})(\\d{4})", "$1-$2-$3");
            }
        }

        /// <summary>
        ///     Formats a string into a readable SSN
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="ssn"></param>
        /// <returns></returns>
        public static string FormatSSN(this HtmlHelper helper, string ssn) 
        {
            return ssn.FormatSSN();
        }

        /// <summary>
        ///     Formats a string into a readable SSN
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="ssn"></param>
        /// <returns></returns>
        public static string FormatSSN(this string ssn) 
        {
            return String.IsNullOrEmpty(ssn) ? String.Empty : ssn.Insert(3, "-").Insert(6, "-");
        }
    }
}
