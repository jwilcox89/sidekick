using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace sidekick
{
    public static class EnumExtensions
    {
        /// <summary>
        ///     Makes list of enums.
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <returns></returns>
        public static IEnumerable<TEnum> GetEnumValues<TEnum>() {
            if (typeof(TEnum).BaseType != typeof(Enum))
                throw new ArgumentException("Must be a type of System.Enum");

            return (TEnum[])Enum.GetValues(typeof(TEnum));
        }

        /// <summary>
        ///     Returns an Enum's DisplayAttribute's name value
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDisplayName<TEnum>(this object value) {
            if (typeof(TEnum).BaseType != typeof(Enum))
                throw new ArgumentException("Must be a type of System.Enum");

            TEnum enumValue = (TEnum)Enum.Parse(typeof(TEnum), value.ToString());
            Type type = enumValue.GetType();
            MemberInfo[] memInfo = type.GetMember(enumValue.ToString());
            Object[] attr = memInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);
            return ((DisplayAttribute)attr[0]).Name;
        }

        /// <summary>
        ///     Returns an Enum's DisplayAttribute's description value
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription<TEnum>(this object value) {
            if (typeof(TEnum).BaseType != typeof(Enum))
                throw new ArgumentException("Must be a type of System.Enum");

            TEnum enumValue = (TEnum)Enum.Parse(typeof(TEnum), value.ToString());
            Type type = enumValue.GetType();
            MemberInfo[] memInfo = type.GetMember(enumValue.ToString());
            Object[] attr = memInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);
            return ((DisplayAttribute)attr[0]).Description;
        }

        /// <summary>
        ///     Returns the HtmlBuilder attribute associated with an enum
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static HtmlBuilderAttribute GetHtmlAttributes<TEnum>(this object value) {
            if (typeof(TEnum).BaseType != typeof(Enum))
                throw new ArgumentException("Must be a type of System.Enum");

            TEnum enumValue = (TEnum)Enum.Parse(typeof(TEnum), value.ToString());
            Type type = enumValue.GetType();
            MemberInfo[] memInfo = type.GetMember(enumValue.ToString());
            Object[] attr = memInfo[0].GetCustomAttributes(typeof(HtmlBuilderAttribute), false);
            return (HtmlBuilderAttribute)attr[0];
        }
    }
}
