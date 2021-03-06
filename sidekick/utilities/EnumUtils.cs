﻿using System;
using System.Reflection;

namespace sidekick
{
    /// <summary>
    ///     Extensions for common functionality used on Enum types
    /// </summary>
    public static class EnumUtils
    {
        /// <summary>
        ///     Returns attribute and its properties for a specific enum
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TAttribute GetAttribute<TAttribute>(this Enum value)
            where TAttribute : Attribute
        {
            if (!Enum.IsDefined(value.GetType(), value))
                throw new ArgumentException("Not a valid Enum");

            Type type = value.GetType();
            return type.GetField(Enum.GetName(type, value)).GetCustomAttribute<TAttribute>(false);
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

            Type type = typeof(TEnum);
            return type.GetField(Enum.GetName(type, value)).GetCustomAttribute<TAttribute>(false);
        }
    }
}
