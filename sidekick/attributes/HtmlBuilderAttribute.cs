using System;

namespace sidekick
{
    public class HtmlBuilderAttribute : Attribute
    {
        /// <summary>
        ///     Primarily used to hold a css class value
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        ///     Primarily used to hold an icon's css class
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        ///     Primarily used to hold the html tag value
        /// </summary>
        public string Tag { get; set; }
    }
}
