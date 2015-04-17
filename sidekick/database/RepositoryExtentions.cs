using System;
using System.Collections.Generic;
using System.Linq;

namespace sidekick
{
    public static class RepositoryExtentions
    {
        /// <summary>
        ///     Selects a random item out of the provided list
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static TSource SelectRandom<TSource>(this IEnumerable<TSource> list) {
            return (list.Count() > 0) ? list.ElementAt(RandomNumber.GetNumber(list.Count())) : list.FirstOrDefault();
        }

        /// <summary>
        ///     Selects a random item out of the provided list
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="list"></param>
        /// <param name="minStartValue"></param>
        /// <returns></returns>
        public static TSource SelectRandom<TSource>(this IEnumerable<TSource> list, int minStartValue) {
            return (list.Count() > 0) ? list.ElementAt(RandomNumber.GetNumber(minStartValue, list.Count())) : list.FirstOrDefault();
        }

        /// <summary>
        ///     Returns the opposite of the provided bool's value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool Toggle(this bool value) {
            return !value;
        }
    }
}
