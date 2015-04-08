using System;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace sidekick
{
    public static class Extentions
    {
        /// <summary>
        ///     Converts an object to an int
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static int ToInt<TObject>(this TObject item) {
            return Convert.ToInt32(item);
        }

        /// <summary>
        ///     Converts a list of an object to a list of ints
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IEnumerable<int> ToInt<TObject>(this IEnumerable<TObject> list) {
            List<int> final = new List<int>();
            foreach (TObject i in list) {
                final.Add(i.ToInt());
            }

            return final;
        }

        /// <summary>
        ///     Converts an object to a short
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static short ToShort<TObject>(this TObject item) {
            return Convert.ToInt16(item);
        }

        /// <summary>
        ///     Converts a list of an object to a list of shorts
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IEnumerable<short> ToShort<TObject>(this IEnumerable<TObject> list) {
            List<short> final = new List<short>();
            foreach (TObject i in list) {
                final.Add(i.ToShort());
            }

            return final;
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
        /// <typeparam name="TObject"></typeparam>
        /// <returns></returns>
        public static IEnumerable<TEnum> GetEnumValues<TEnum>() {
            if (typeof(TEnum).BaseType != typeof(Enum))
                throw new ArgumentException("Must be a type of System.Enum");

            return (TEnum[])Enum.GetValues(typeof(TEnum));
        }

        /// <summary>
        ///     Returns an Enum's DisplayAttribute's name value
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDisplayName<TEnum>(object value) {
            if (typeof(TEnum).BaseType != typeof(Enum))
                throw new ArgumentException("Must be a type of System.Enum");

            TEnum enumValue = (TEnum)Enum.Parse(typeof(TEnum), value.ToString());
            Type type = enumValue.GetType();
            MemberInfo[] memInfo = type.GetMember(enumValue.ToString());
            Object[] attr = memInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);
            return ((DisplayAttribute)attr[0]).Name;
        }

        /// <summary>
        ///     Returns an Enum's DisplayAttribute's description value
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription<TEnum>(object value) {
            if (typeof(TEnum).BaseType != typeof(Enum))
                throw new ArgumentException("Must be a type of System.Enum");

            TEnum enumValue = (TEnum)Enum.Parse(typeof(TEnum), value.ToString());
            Type type = enumValue.GetType();
            MemberInfo[] memInfo = type.GetMember(enumValue.ToString());
            Object[] attr = memInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);
            return ((DisplayAttribute)attr[0]).Description;
        }

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

        /// <summary>
        ///     Returns the last 4 characters of a string (.pdf, .doc etc)
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string GetFileExtention(this string text) {
            return text.Substring(text.Length - 4);
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
