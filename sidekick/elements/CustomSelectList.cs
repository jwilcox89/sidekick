using System.Collections.Generic;
using System.Web.Mvc;

namespace sidekick
{
    /// <summary>
    ///     Create a custom select list
    /// </summary>
    public class CustomSelectList
    {
        public IList<SelectListItem> Items { get; set; }

        public CustomSelectList(string text, string value)
        {
            Items = new List<SelectListItem>();
            Items.Add(new SelectListItem
            {
                Text = text,
                Value = value
            });
        }

        public CustomSelectList(SelectListItem option)
        {
            Items = new List<SelectListItem>();
            Items.Add(option);
        }

        public CustomSelectList Add(string text, string value)
        {
            Items.Add(new SelectListItem
            {
                Text = text,
                Value = value
            });

            return this;
        }

        public CustomSelectList Add(SelectListItem option)
        {
            Items.Add(option);
            return this;
        }
    }
}
