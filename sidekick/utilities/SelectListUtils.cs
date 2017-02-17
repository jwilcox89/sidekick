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
            IList<SelectListItem> list = new List<SelectListItem>();

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
        ///     Generates a dropdown of all the United States. Abbreviations used for both display and value.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> StateDropdown(bool useAbbreviation)
        {
            IList<SelectListItem> list = new List<SelectListItem>();

            foreach (UsStates state in Enum.GetValues(typeof(UsStates)))
            {
                list.Add(new SelectListItem
                {
                    Text = useAbbreviation ? state.ToString() : state.GetAttribute<DescriptionAttribute>().Description,
                    Value = state.ToString(),
                });
            }

            return list;
        }

        /// <summary>
        ///     Generates a dropdown of all the United States. Abbreviations used for both display and value. 
        /// </summary>
        /// <param name="selectedState">Default selected state if no state already selected</param>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> StateDropdown(bool useAbbreviation, UsStates selectedState)
        {
            IList<SelectListItem> list = new List<SelectListItem>();

            foreach (UsStates state in Enum.GetValues(typeof(UsStates)))
            {
                list.Add(new SelectListItem
                {
                    Text = useAbbreviation ? state.ToString() : state.GetAttribute<DescriptionAttribute>().Description,
                    Value = state.ToString(),
                    Selected = state.ToString() == selectedState.ToString() ? true : false
                });
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
    }
}
