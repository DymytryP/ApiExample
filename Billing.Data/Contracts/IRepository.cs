using Billing.Data.Queries.Include;
using Billing.Data.Queries.Mappings;
using Billing.Data.Queries.Specification;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.Data.Contracts
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Finds first entity matching query.
        /// </summary>
        /// <param name="baseQuery">Base LINQ query</param>
        /// <param name="specification">The specification to filter data.</param>
        /// <param name="mapping">Mapping from entity to DTO model.</param>
        /// <param name="include">Included foreign entities properties.</param>
        /// <returns>Matching entity or null.</returns>
        TResult FindFirst<TResult>(
            Specification<T> specification,
            Mapping<T,TResult> mapping,
            Include<T> include = null);

        /// <summary>
        /// Finds first entity matching query asynchronously.
        /// </summary>
        /// <param name="baseQuery">Base LINQ query</param>
        /// <param name="specification">The specification to filter data.</param>
        /// <param name="mapping">Mapping from entity to DTO model.</param>
        /// <param name="include">Included foreign entities properties.</param>
        /// <returns>Matching entity or null.</returns>
        Task<TResult> FindFirstAsync<TResult>(
            Specification<T> specification,
            Mapping<T, TResult> mapping,
            Include<T> include = null);

        /// <summary>
        /// Inserts entity into database.
        /// </summary>
        /// <param name="entity">Entity.</param>
        void Insert(T entity);

        /// <summary>
        /// Inserts entity into database asynchronously.
        /// </summary>
        /// <param name="entity">Entity.</param>
        /// <returns></returns>
        Task InsertAsync(T entity);
    }
}
