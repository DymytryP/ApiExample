using System.Linq.Expressions;

namespace Billing.Data.Expressions
{
    /// <summary>
    /// Expression parameter replacer. Derives from <see cref="ExpressionVisitor"/>.
    /// When chaining expressions replaces parameter expressions to refer to same parameter expression.
    /// </summary>
    internal class ParameterReplacer : ExpressionVisitor
    {
        private readonly ParameterExpression _parameter;

        internal ParameterReplacer(ParameterExpression parameter)
        {
            _parameter = parameter;
        }

        /// <summary>
        /// Overrides default VisitParameter behavior and always replaces parameter expression.
        /// </summary>
        /// <param name="node">Node to visit</param>
        /// <returns>Returns new parameter expression.</returns>
        protected override Expression VisitParameter(ParameterExpression node)
            => base.VisitParameter(_parameter);
    }
}
