using System.Web.Mvc;

namespace sidekick
{
    /// <summary>
    ///     Designed to help keep TempData values organized and unique.
    /// </summary>
    public class TempDataManager
    {
        public TempDataDictionary TempData { get; set; }

        public TempDataManager(TempDataDictionary data)
        {
            TempData = data;
        }

        /// <summary>
        ///     Adds a key/value pair to temp data. If the key already exists in temp data it is removed prior to adding it.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(string key, object value)
        {
            Remove(key);
            TempData.Add(key, value);
        }

        /// <summary>
        ///     Removes a key/value pair from temp data.
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            if (TempData.ContainsKey(key))
                TempData.Remove(key);
        }
    }
}
