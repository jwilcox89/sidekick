using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq.Expressions;
using System.Linq;

namespace sidekick
{
    public static class SelectListHelpers
    {
        /// <summary>
        ///     Generates a dropdown of years
        /// </summary>
        /// <param name="yearsForward">How many years forward from the current year do you want to display?</param>
        /// <param name="yearsBackward">How many years backward from the current year do you want to display?</param>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> YearDropdown(int yearsForward, int yearsBackward)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            int start = DateTime.Now.Year - yearsBackward;
            int end = DateTime.Now.Year + yearsForward;
            int placeholder = start;

            while (placeholder >= start && placeholder <= end)
            {
                list.Add(new SelectListItem
                {
                    Text = placeholder.ToString(),
                    Value = placeholder.ToString()
                });

                placeholder++;
            }

            return list;
        }

        /// <summary>
        ///     Generates a simple True/False dropdown into a usable format.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> YesNoDropdown()
        {
            return YesNoDropdown("Yes", "No");
        }

        /// <summary>
        ///     Generates a simple True/False dropdown into a usable format.
        /// </summary>
        /// <param name="trueValue">What you want the true option to say (ex. "Yes")</param>
        /// <param name="falseValue">What you want the false option to say (ex. "No)</param>
        /// <param name="defaultText"></param>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> YesNoDropdown(string trueValue, string falseValue)
        {
            return new List<SelectListItem>
            { 
                new SelectListItem { Text = trueValue, Value = "True" },
                new SelectListItem { Text = falseValue, Value = "False" } 
            };
        }

        public static IEnumerable<SelectListItem> BuildSelectList(CustomSelectList items)
        {
            return items.Items;
        }

        /// <summary>
        ///     Generates a dropdown list
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="items"></param>
        /// <param name="value"></param>
        /// <param name="display"></param>
        /// <param name="selectedValue"></param>
        /// <returns></returns>
        public static SelectList BuildSelectList<TSource>(IEnumerable<TSource> items, Expression<Func<TSource, object>> value, Expression<Func<TSource, object>> display, object selectedValue = null)
        {
            return BuildSelectList(items, value.GetMemberName(), display.GetMemberName(), selectedValue);
        }

        /// <summary>
        ///     Generates a dropdown list
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static SelectList BuildSelectList<TSource>(IEnumerable<TSource> items)
        {
            return BuildSelectList(items, "", "", null);
        }

        /// <summary>
        ///     Generates a dropdown list
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="items"></param>
        /// <param name="selectedValue"></param>
        /// <returns></returns>
        public static SelectList BuildSelectList<TSource>(IEnumerable<TSource> items, object selectedValue)
        {
            return BuildSelectList(items, "", "", selectedValue);
        }

        /// <summary>
        ///     Generates a dropdown list
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="items"></param>
        /// <param name="value"></param>
        /// <param name="display"></param>
        /// <param name="selectedValue"></param>
        /// <returns></returns>
        public static SelectList BuildSelectList<TSource>(IEnumerable<TSource> items, string value, string display, object selectedValue)
        {
            items = items as List<TSource> ?? items.ToList();
            return new SelectList(items, value, display, selectedValue);
        }
    }
}
