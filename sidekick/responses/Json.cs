using System.Collections.Generic;
using Newtonsoft.Json;

namespace sidekick
{
    public class Json
    {
        private IDictionary<string,object> _response;

        /// <summary>
        ///     Generates a Json result
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public Json(string key, object value) {
            _response = new Dictionary<string,object>();
            _response.Add(key, value);
        }

        /// <summary>
        ///     Add an item to the Json response
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Json Add(string key, object value) {
            _response.Add(key, value);
            return this;
        }

        /// <summary>
        ///     Renders the list of items into a Json response
        /// </summary>
        /// <returns></returns>
        public object Build() {
            return JsonConvert.SerializeObject(_response);
        }
    }
}
