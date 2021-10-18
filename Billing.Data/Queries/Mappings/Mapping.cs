using System;
using System.Linq;
using System.Linq.Expressions;

namespace Billing.Data.Queries.Mappings
{
    /// <summary>
    /// <para>
    /// Represents the mapping lambda expression for Select part for LINQ T-SQL query.
    /// Allows to limit generated query to mapped fields only.
    /// </para>
    /// <para>
    /// Created for the purpose of implementing repository pattern, but without cluttering repository
    /// with different methods implementations for different data queries.
    /// </para>
    /// </summary>
    public class Mapping<T, TResult>
    {
        protected virtual Expression<Func<T, TResult>> MappingExpression { get; set; }

        public Mapping(Expression<Func<T, TResult>> mappingExpression)
        {
            mappingExpression = mappingExpression ?? throw new ArgumentNullException(nameof(mappingExpression));

            var memberInitExpression = mappingExpression.Body as MemberInitExpression;
            memberInitExpression = memberInitExpression ??
                throw new ArgumentException(
                    "Mapping expression should be MemberInitExpression, " +
                        "e.g. c => new CustomDto(){ Property1 = c.Property1, Property2 = c.NavigationProperty.Property1}",
                    nameof(mappingExpression));

            if (mappingExpression.Parameters.Count != 1)
            {
                throw new ArgumentException("Mapping expression should contain 1 parameter", nameof(mappingExpression));
            }

            MappingExpression = mappingExpression;
        }

        public Expression<Func<T, TResult>> ToExpression()
        {
            return MappingExpression;
        }
    }
}
