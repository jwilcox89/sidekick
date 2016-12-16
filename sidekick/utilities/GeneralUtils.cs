using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;

namespace sidekick
{
    /// <summary>
    ///     General expression extensions
    /// </summary>
    public static class GeneralUtils
    {
        /// <summary>
        ///     Returns the member information for the expression
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public static MemberExpression GetMemberInfo(this Expression method) 
        {
            LambdaExpression lambda = method as LambdaExpression;

            if (lambda == null)
                throw new ArgumentNullException("No method");

            MemberExpression memberEx = null;

            if (lambda.Body.NodeType == ExpressionType.Convert) 
            {
                memberEx = ((UnaryExpression)lambda.Body).Operand as MemberExpression;
            } 
            else if (lambda.Body.NodeType == ExpressionType.MemberAccess) 
            {
                memberEx = lambda.Body as MemberExpression;
            }

            if (memberEx == null)
                throw new ArgumentNullException("No method");

            return memberEx;
        }

        /// <summary>
        ///     Returns the member name from the member expression
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public static string GetMemberName(this Expression method) 
        {
            return method.GetMemberInfo().Member.Name;
        }

        public static PropertyInfo GetProperty<TEntity>(this TEntity entity, string name) 
        {
            return entity.GetType().GetProperty(name);
        }

        /// <summary>
        ///     Returns the opposite of the provided bool's value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool Toggle(this bool value) 
        {
            return !value;
        }
    }
}
