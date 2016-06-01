using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace sidekick
{
    /// <summary>
    ///     Create a custom select list
    /// </summary>
    public class CustomSelectList
    {
        private IList<SelectListItem> _items;
        public IList<SelectListItem> Items => _items;

        public CustomSelectList(string text, string value)
        {
            _items = new List<SelectListItem>();
            _items.Add(new SelectListItem
            {
                Text = text,
                Value = value
            });
        }

        public CustomSelectList Add(string text, string value)
        {
            _items.Add(new SelectListItem
            {
                Text = text,
                Value = value
            });

            return this;
        }
    }
}
