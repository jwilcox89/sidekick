using System;

namespace sidekick
{
    public class HtmlBuilderAttribute : Attribute
    {
        public string Class { get; set; }
        public string Icon { get; set; }
        public string Tag { get; set; }
    }
}
