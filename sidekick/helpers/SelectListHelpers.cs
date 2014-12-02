using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace sidekick
{
    public class SelectListHelpers
    {
        /// <summary>
        ///     Generates a simple True/False dropdown into a usable format.
        /// </summary>
        /// <param name="trueValue"></param>
        /// <param name="falseValue"></param>
        /// <param name="defaultText"></param>
        /// <returns></returns>
        public static SelectList YesNoDropdown(string trueValue = "Yes", string falseValue = "No", string defaultText = "") {

            var list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = trueValue, Value = "True" });
            list.Add(new SelectListItem() { Text = falseValue, Value = "False" });

            return new SelectList(list, defaultText);
        }

        /// <summary>
        ///     Generates a dropdown list dynamically.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <returns></returns>
        public static SelectList BuildSelectList<T>(Action<CustomSelectList<T>> action) where T : class, new() {

            var list = new CustomSelectList<T>();
            action(list);

            return new SelectList(list.ItemList, list.Value, list.Display, list.SelectedValue);
        }
    }
}
