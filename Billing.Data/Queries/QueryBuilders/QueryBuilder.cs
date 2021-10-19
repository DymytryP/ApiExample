using Billing.Data.Contracts;
using Billing.Data.Queries.Include;
using Billing.Data.Queries.Mappings;
using Billing.Data.Queries.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Billing.Data.Queries.QueryBuilders
{
    public class QueryBuilder<T> : IQueryBuilder<T> where T : class
    {
        /// <inheritdoc/>
        public IQueryable<T> BuildQuery(
            IQueryable<T> baseQuery,
            Specification<T> specification,
            Include<T> include = null)
        {
            specification = specification
                ?? throw new ArgumentNullException(nameof(specification));

            var includes = include?.GetIncludes() ?? new List<Expression<Func<T, object>>>();
            includes
                .ForEach(expression =>
                {
                    baseQuery = baseQuery.Include(expression);
                });

            var filteredQuery = baseQuery.Where(specification.ToExpression());

            return filteredQuery;
        }

        /// <inheritdoc/>
        public IQueryable<TResult> BuildQuery<TResult>(
            IQueryable<T> baseQuery,
            Specification<T> specification,
            Mapping<T, TResult> mapping,
            Include<T> include = null)
        {
            var includes = include?.GetIncludes() ?? new List<Expression<Func<T, object>>>();
            includes
                .ForEach(expression =>
                {
                    baseQuery = baseQuery.Include(expression);
                });

            var filteredQuery = baseQuery
                .Where(specification.ToExpression())
                .Select(mapping.ToExpression());

            return filteredQuery;
        }
    }
}
