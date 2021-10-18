using Billing.Data.Contracts;
using Billing.Data.Queries.Include;
using Billing.Data.Queries.Mappings;
using Billing.Data.Queries.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BillingDbContext context;

        private readonly IQueryBuilder<T> queryBuilder;

        public Repository(
            BillingDbContext context,
            IQueryBuilder<T> queryBuilder)
        {
            this.context = context;
            this.queryBuilder = queryBuilder;
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        public TResult FindFirst<TResult>(
            Specification<T> specification,
            Mapping<T, TResult> mapping,
            Include<T> include = null)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<TResult> FindFirstAsync<TResult>(
            Specification<T> specification,
            Mapping<T, TResult> mapping,
            Include<T> include = null)
        {
            var baseQuery = QueryAsNoTracking();
            var query = queryBuilder.BuildQuery(baseQuery, specification, mapping);
            var result = await query.FirstOrDefaultAsync();

            return result;
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task InsertAsync(T entity)
        {
            context.Set<T>().Add(entity);

            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Creates base IQueryable for building query with .AsNoTracking().
        /// </summary>
        /// <returns>IQueryble of type T.</returns>
        protected virtual IQueryable<T> QueryAsNoTracking()
        {
            return context.Set<T>()
                .AsNoTracking()
                .AsQueryable();
        }
    }
}
