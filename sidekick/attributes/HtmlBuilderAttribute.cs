﻿using System;

namespace sidekick
{
    /// <summary>
    ///     Assign HTML attributes to properties or fields for use with HTML builders.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
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

        /// <summary>
        ///     Used to hold the bootstrap color value
        /// </summary>
        public Colors Color { get; set; }
    }
}
