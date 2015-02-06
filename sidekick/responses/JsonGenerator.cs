using System.Collections.Generic;
using Newtonsoft.Json;

namespace sidekick
{
    public class JsonGenerator
    {
        private IDictionary<string,object> _jsonList;

        /// <summary>
        ///     Generates a Json result
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public JsonGenerator(string key, object value) {
            _jsonList = new Dictionary<string,object>();
            _jsonList.Add(key, value);
        }

        public JsonGenerator Add(string key, object value) {
            _jsonList.Add(key, value);
            return this;
        }

        public object Build() {
            return JsonConvert.SerializeObject(_jsonList);
        }
    }
}
