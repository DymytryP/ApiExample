using System;
using System.Linq.Expressions;

namespace Billing.Data.Queries.Specification
{
    /// <summary>
    /// <para>Represents the filter lambda expression for Where condition for LINQ T-SQL query.</para>
    /// <para>Derived generic types represent chaining and inversing conditions.</para>
    /// <para>Derived non-generic types represent different single conditions for data entities' filtering.</para>
    /// <para>
    /// Created for the purpose of implementing repository pattern, but without cluttering repository
    /// with different methods implementations for different data queries.
    /// </para>
    /// </summary>
    public abstract class Specification<T>
    {
        /// <summary>
        /// Creates expression tree.
        /// </summary>
        /// <returns>The expression tree.</returns>
        public abstract Expression<Func<T, bool>> ToExpression();

        /// <summary>
        /// Composes specifications with AND.
        /// </summary>
        /// <param name="specification">Specification to add.</param>
        /// <returns>Composed AND specification.</returns>
        public Specification<T> And(Specification<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }

        /// <summary>
        /// Composes specifications with OR.
        /// </summary>
        /// <param name="specification">Specification to add.</param>
        /// <returns>Composed OR specification.</returns>
        public Specification<T> Or(Specification<T> specification)
        {
            return new OrSpecification<T>(this, specification);
        }

        /// <summary>
        /// Inverts specification condition.
        /// </summary>
        /// <param name="specification">Specification to invert.</param>
        /// <returns>Inverted specification.</returns>
        public Specification<T> Not()
        {
            return new NotSpecification<T>(this);
        }
    }
}
