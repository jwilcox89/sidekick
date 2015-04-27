using System;
using System.Linq.Expressions;

namespace sidekick
{
    public static class GeneralExtentions
    {
        public static MemberExpression GetMemberInfo(this Expression method) {
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
