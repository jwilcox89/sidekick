using System.Web.Mvc;

namespace sidekick
{
    /// <summary>
    ///     Designed to help keep TempData values organized.
    /// </summary>
    public class TempDataManager
    {
        public TempDataDictionary TempData { get; set; }

        public void Add(string key, object value) {
            Remove(key);
            TempData.Add(key, value);
        }

        public void Remove(string key) {
            if (TempData.ContainsKey(key))
                TempData.Remove(key);
        }
    }
}
