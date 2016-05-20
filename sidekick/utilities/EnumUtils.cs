using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace sidekick
{
    /// <summary>
    ///     Extensions for common functionality used on Enum types
    /// </summary>
    public static class EnumUtils
    {
        /// <summary>
        ///     Makes list of enums.
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <returns></returns>
        public static IEnumerable<TEnum> GetEnumValues<TEnum>()
        {
            if (typeof(TEnum).BaseType != typeof(Enum))
                throw new ArgumentException("Must be a type of System.Enum");

            return (TEnum[])Enum.GetValues(typeof(TEnum));
        }

        /// <summary>
        ///     Returns attribute and its properties for a specific enum
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TAttribute GetAttribute<TEnum, TAttribute>(this object value)
            where TAttribute : Attribute
        {
            if (typeof(TEnum).BaseType != typeof(Enum))
                throw new ArgumentException("Must be a type of System.Enum");

            TEnum enumValue = (TEnum)Enum.Parse(typeof(TEnum), value.ToString());
            Type type = enumValue.GetType();
            MemberInfo[] memInfo = type.GetMember(enumValue.ToString());
            Object[] attr = memInfo[0].GetCustomAttributes(typeof(TAttribute), false);
            return (TAttribute)attr[0];
        }
    }
}
