﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace sidekick
{
    /// <summary>
    ///     Extension methods for different types of common conversions.
    /// </summary>
    public static class ConversionExtensions
    {
        /// <summary>
        ///     Converts an object to an int
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static int ToInt<T>(this T item)
        {
            return Convert.ToInt32(item);
        }

        /// <summary>
        ///     Converts a list of an object to a list of ints
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IEnumerable<int> ToInt<T>(this IEnumerable<T> list)
        {
            return list.Select(x => x.ToInt());
        }

        /// <summary>
        ///     Converts a list of an object to a list of ints
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IEnumerable<int> ToInt<T>(this IList<T> list)
        {
            return list.AsEnumerable().ToInt();
        }

        /// <summary>
        ///     Converts an array of an object to a list of ints
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IEnumerable<int> ToInt<T>(this T[] list)
        {
            return list.AsEnumerable().ToInt();
        }

        /// <summary>
        ///     Converts an object to a short
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static short ToShort<T>(this T item)
        {
            return Convert.ToInt16(item);
        }

        /// <summary>
        ///     Converts a list of an object to a list of shorts
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IEnumerable<short> ToShort<T>(this IEnumerable<T> list)
        {
            return list.Select(x => x.ToShort());
        }

        /// <summary>
        ///     Converts a list of an object to a list of shorts
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IEnumerable<short> ToShort<T>(this IList<T> list)
        {
            return list.AsEnumerable().ToShort();
        }

        /// <summary>
        ///     Converts an arrary of an object to a list of shorts
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IEnumerable<short> ToShort<T>(this T[] list)
        {
            return list.AsEnumerable().ToShort();
        }

        /// <summary>
        ///     Converts a long integer to a double value that represents the size in MBs. Rounded to 2 decimal places.
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static double ConvertToMB(this long bytes)
        {
            return Math.Round((bytes / 1024f) / 1024f, 2);
        }

        /// <summary>
        ///     Converts a long integer to a double value that represents the size in MBs.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="decimalPlaces">Round to this decimal place</param>
        /// <returns></returns>
        public static double ConvertToMB(this long bytes, int decimalPlaces)
        {
            return Math.Round((bytes / 1024f) / 1024f, decimalPlaces);
        }

        /// <summary>
        ///     Loops through each day in a date range
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static IEnumerable<DateTime> ForEachDay(this DateTime start, DateTime end)
        {
            DateTime currentDay = new DateTime(start.Year, start.Month, start.Day);
            while (currentDay <= end)
            {
                yield return currentDay;
                currentDay = currentDay.AddDays(1);
            }
        }

        /// <summary>
        ///     Loops through each month in a date range
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static IEnumerable<DateTime> ForEachMonth(this DateTime start, DateTime end)
        {
            DateTime currentMonth = new DateTime(start.Year, start.Month, 1);
            while (currentMonth <= end)
            {
                yield return currentMonth;
                currentMonth = currentMonth.AddMonths(1);
            }
        }

        /// <summary>
        ///     Loops through each year in a date range.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static IEnumerable<DateTime> ForEachYear(this DateTime start, DateTime end)
        {
            DateTime currentMonth = new DateTime(start.Year, start.Month, 1);
            int currentYear = currentMonth.Year;
            while (currentMonth <= end)
            {
                if (currentMonth.Year != currentYear)
                {
                    currentYear = currentMonth.Year;
                    yield return currentMonth;
                }

                currentMonth = currentMonth.AddMonths(1);
            }
        }
    }
}
