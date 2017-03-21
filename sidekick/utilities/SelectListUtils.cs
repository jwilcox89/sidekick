using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq.Expressions;
using System.Linq;
using System.ComponentModel;

namespace sidekick
{
    /// <summary>
    ///     SelectList builders
    /// </summary>
    public static class SelectListUtils
    {
        /// <summary>
        ///     Generates a dropdown of years
        /// </summary>
        /// <param name="yearsForward">How many years forward from the current year do you want to display?</param>
        /// <param name="yearsBackward">How many years backward from the current year do you want to display?</param>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> YearDropdown(int yearsForward, int yearsBackward)
        {
            return Enumerable.Range(DateTime.Now.Year - yearsBackward, (DateTime.Now.Year + yearsForward) - (DateTime.Now.Year - yearsBackward))
                .Union(new[] { DateTime.Now.Year })
                .OrderBy(x => x)
                .Select(x => new SelectListItem
                {
                    Text = x.ToString(),
                    Value = x.ToString()
                });
        }

        /// <summary>
        ///     Generates a dropdown of all the United States. Abbreviations used for both display and value.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> StateDropdown(bool useAbbreviation)
        {
            return new List<SelectListItem>(Enum.GetValues(typeof(UsStates))
                .Cast<UsStates>()
                .Select(x => new SelectListItem
                {
                    Text = useAbbreviation ? x.ToString() : x.GetAttribute<DescriptionAttribute>().Description,
                    Value = x.ToString()
                }));
        }

        /// <summary>
        ///     Generates a dropdown of all the United States. Abbreviations used for both display and value. 
        /// </summary>
        /// <param name="selectedState">Default selected state if no state already selected</param>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> StateDropdown(bool useAbbreviation, UsStates selectedState)
        {
            return new List<SelectListItem>(Enum.GetValues(typeof(UsStates))
                .Cast<UsStates>()
                .Select(x => new SelectListItem
                {
                    Text = useAbbreviation ? x.ToString() : x.GetAttribute<DescriptionAttribute>().Description,
                    Value = x.ToString(),
                    Selected = x.ToString() == selectedState.ToString() ? true : false
                }));
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
            return BuildDropdown(new SelectListItem { Text = trueValue, Value = "True" }, new SelectListItem { Text = falseValue, Value = "False" });
        }

        /// <summary>
        ///     Build a custom dropdown
        /// </summary>
        /// <param name="items">List of select items</param>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> BuildDropdown(params SelectListItem[] items)
        {
            return new List<SelectListItem>(items);
        }
    }
}
