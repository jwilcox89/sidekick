using System;
using System.Collections.Generic;

namespace sidekick
{
    public static class ConversionExtensions
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
    }
}
