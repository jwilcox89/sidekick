using System;

namespace sidekick
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class ExtensionAttribute : Attribute
    {
        public string Extension { get; set; }

        public ExtensionAttribute(string extension)
        {
            Extension = extension;
        }
    }
}
