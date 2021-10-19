using Billing.Data;
using Billing.Data.Contracts;
using Billing.Data.Models.Entities;
using Billing.Data.Repositories;
using Billing.Infrastructure.Contracts;
using System.Threading.Tasks;

namespace Billing.Infrastructure.Implementations
{
    public class OrderDataTarget : Repository<Order>, IDataTarget<Order>
    {
        public OrderDataTarget(BillingDbContext context, IQueryBuilder<Order> queryBuilder)
            : base(context, queryBuilder)
        {
        }

        /// <summary>
        /// Recei
        /// </summary>
        /// <param name="data"></param>
        public async void Receive(Order order)
        {
            await base.InsertAsync(order);
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        public Task ReceiveAsync(Order data)
        {
            throw new System.NotImplementedException();
        }
    }
}
