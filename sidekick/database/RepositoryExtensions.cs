using System;
using System.Linq;
using System.Collections.Generic;

namespace sidekick
{
    public static class RepositoryExtensions
    {
        /// <summary>
        ///     Returns all distinct elements as determined by the selector that the uniqueness will be determined by.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> DistinctBy<TSource,TKey>(this IEnumerable<TSource> source, Func<TSource,TKey> selector) {
            return source.GroupBy(selector).Select(x => x.First());
        }
    }
}
