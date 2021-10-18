using Billing.Data.Expressions;
using System;
using System.Linq.Expressions;

namespace Billing.Data.Queries.Specification
{
    public class NotSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _specification;

        public NotSpecification(Specification<T> specification)
        {
            _specification = specification;
        }

        /// <inheritdoc/>
        public override Expression<Func<T, bool>> ToExpression()
        {
            var specificationExpression = _specification.ToExpression();
            var paramExpr = Expression.Parameter(typeof(T));

            var exprBody = Expression.Not(
                specificationExpression.Body);
            exprBody = (UnaryExpression)new ParameterReplacer(paramExpr).Visit(exprBody);
            var finalExpr = Expression.Lambda<Func<T, bool>>(exprBody, paramExpr);

            return finalExpr;
        }
    }
}
