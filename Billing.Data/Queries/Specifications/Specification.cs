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
        public abstract Expression<Func<T, bool>> ToExpression();

        public Specification<T> And(Specification<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }

        public Specification<T> Or(Specification<T> specification)
        {
            return new OrSpecification<T>(this, specification);
        }

        public Specification<T> Not()
        {
            return new NotSpecification<T>(this);
        }
    }
}
