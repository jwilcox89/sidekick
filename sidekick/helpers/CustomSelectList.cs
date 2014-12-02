using System.Collections.Generic;

namespace sidekick
{
    public class CustomSelectList<T>
    {
        public string         Value         { get; set; }
        public string         Display       { get; set; }
        public object         SelectedValue { get; set; }
        public IEnumerable<T> ItemList      { get; set; }
    }
}
