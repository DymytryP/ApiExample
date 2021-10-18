using Billing.Data.Queries.Include;
using Billing.Data.Queries.Mappings;
using Billing.Data.Queries.Specification;
using System.Linq;

namespace Billing.Data.Contracts
{
    public interface IQueryBuilder<T> where T : class
    {
        /// <summary>
        /// Builds LINQ query.
        /// </summary>
        /// <param name="baseQuery">Base LINQ query</param>
        /// <param name="specification">The specification to filter data.</param>
        /// <param name="include">Included foreign entities properties.</param>
        /// <returns>IQueryable for EF to generate query from.</returns>
        IQueryable<T> BuildQuery(
            IQueryable<T> baseQuery,
            Specification<T> specification,
            Include<T> include = null);

        /// <summary>
        /// Builds LINQ query.
        /// </summary>
        /// <param name="baseQuery">Base LINQ query</param>
        /// <param name="specification">The specification to filter data.</param>
        /// <param name="mapping">Mapping from entity to DTO model.</param>
        /// <param name="include">Included foreign entities properties.</param>
        /// <returns>IQueryable for EF to generate query from.</returns>
        public IQueryable<TResult> BuildQuery<TResult>(
            IQueryable<T> baseQuery,
            Specification<T> specification,
            Mapping<T, TResult> mapping,
            Include<T> include = null);
    }
}
