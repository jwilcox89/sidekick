using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq.Expressions;
using System.Linq;

namespace sidekick
{
    public class SelectListHelpers
    {
        /// <summary>
        ///     Generates a dropdown of years
        /// </summary>
        /// <param name="forwardCount">How many years forward from the current year do you want to display?</param>
        /// <param name="backwardCount">How many years backward from the current year do you want to display?</param>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> YearDropdown(int forwardCount, int backwardCount) {
            List<SelectListItem> list = new List<SelectListItem>();

            int currentYear = DateTime.Now.Year;
            int start = currentYear - backwardCount;
            int end = currentYear + forwardCount;
            int placeholder = start;

            while(placeholder >= start && placeholder <= end) {
                list.Add(new SelectListItem { Text = placeholder.ToString(), Value = placeholder.ToString() });
                placeholder++;
            }

            return list;
        }

        /// <summary>
        ///     Generates a simple True/False dropdown into a usable format.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> YesNoDropdown() {
            return new List<SelectListItem> { new SelectListItem { Text = "Yes",  Value = "True" }, 
                                              new SelectListItem { Text = "No", Value = "False" } };
        }

        /// <summary>
        ///     Generates a simple True/False dropdown into a usable format.
        /// </summary>
        /// <param name="trueValue">What you want the true option to say (ex. "Yes")</param>
        /// <param name="falseValue">What you want the false option to say (ex. "No)</param>
        /// <param name="defaultText"></param>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> YesNoDropdown(string trueValue, string falseValue, string defaultText = "") {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = trueValue, Value = "True" });
            list.Add(new SelectListItem() { Text = falseValue, Value = "False" });

            return list;
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
        public static SelectList BuildSelectList<TSource>(IEnumerable<TSource> items, Expression<Func<TSource,object>> value, Expression<Func<TSource,object>> display, object selectedValue) {
            return BuildSelectList(items, GetMemberInfo(value).Member.Name, GetMemberInfo(display).Member.Name, selectedValue);
        }

        /// <summary>
        ///     Generates a dropdown list
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static SelectList BuildSelectList<TSource>(IEnumerable<TSource> items) {
            return BuildSelectList(items, "", "", null);
        }

        /// <summary>
        ///     Generates a dropdown list
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="items"></param>
        /// <param name="selectedValue"></param>
        /// <returns></returns>
        public static SelectList BuildSelectList<TSource>(IEnumerable<TSource> items, object selectedValue) {
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
        public static SelectList BuildSelectList<TSource>(IEnumerable<TSource> items, string value, string display, object selectedValue) {
            items = items as List<TSource> ?? items.ToList();
            return new SelectList(items, value, display, selectedValue);
        }

        private static MemberExpression GetMemberInfo(Expression method) {
            LambdaExpression lambda = method as LambdaExpression;

            if (lambda == null)
                throw new ArgumentNullException("No method");

            MemberExpression memberEx = null;

            if (lambda.Body.NodeType == ExpressionType.Convert) {
                memberEx = ((UnaryExpression)lambda.Body).Operand as MemberExpression;
            } else if (lambda.Body.NodeType == ExpressionType.MemberAccess) {
                memberEx = lambda.Body as MemberExpression;
            }

            if (memberEx == null)
                throw new ArgumentNullException("No method");

            return memberEx;
        }
    }
}
