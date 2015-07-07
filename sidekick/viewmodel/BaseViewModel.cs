using System.Collections.Generic;

namespace sidekick
{
    /// <summary>
    ///     View Model pre populated with commonly used elements
    /// </summary>
    /// <typeparam name="T">Object that is displayed on page</typeparam>
    public class BaseViewModel<T> where T : class
    {
        public T Entity { get; set; }
        public IEnumerable<T> EntityList { get; set; }
    }
}
