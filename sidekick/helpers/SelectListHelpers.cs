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
        ///     Generates a simple True/False dropdown into a usable format.
        /// </summary>
        /// <returns></returns>
        public static SelectList YesNoDropdown() {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "Yes", Value = "True" });
            list.Add(new SelectListItem() { Text = "No", Value = "False" });

            return new SelectList(list, "");
        }

        /// <summary>
        ///     Generates a simple True/False dropdown into a usable format.
        /// </summary>
        /// <param name="trueValue">What you want the true option to say (ex. "Yes")</param>
        /// <param name="falseValue">What you want the false option to say (ex. "No)</param>
        /// <param name="defaultText"></param>
        /// <returns></returns>
        public static SelectList YesNoDropdown(string trueValue, string falseValue, string defaultText = "") {
            List<SelectListItem> list = new List<SelectListItem>();
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
        public static SelectList BuildSelectList<T>(Action<CustomSelectList<T>> action) {
            CustomSelectList<T> list = new CustomSelectList<T>();
            action(list);

            list.ItemList = list.ItemList as List<T> ?? list.ItemList.ToList(); 

            return new SelectList(list.ItemList, GetMemberInfo(list.Value).Member.Name, GetMemberInfo(list.Display).Member.Name, list.SelectedValue);
        }

        /// <summary>
        ///     Generates a dropdown list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static SelectList BuildSelectList<T>(IEnumerable<T> items) {
            return BuildSelectList(items, "", "", null);
        }

        /// <summary>
        ///     Generates a dropdown list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="selectedValue"></param>
        /// <returns></returns>
        public static SelectList BuildSelectList<T>(IEnumerable<T> items, object selectedValue) {
            return BuildSelectList(items, "", "", selectedValue);
        }

        /// <summary>
        ///     Generates a dropdown list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="value"></param>
        /// <param name="display"></param>
        /// <param name="selectedValue"></param>
        /// <returns></returns>
        public static SelectList BuildSelectList<T>(IEnumerable<T> items, string value, string display, object selectedValue) {
            items = items as List<T> ?? items.ToList();
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
