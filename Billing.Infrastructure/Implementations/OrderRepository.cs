using Billing.Data.Contracts;
using Billing.Data.Models.Entities;

namespace Billing.Data.Repositories
{
    public class OrderRepository : Repository<Order>
    {
        public OrderRepository(BillingDbContext context, IQueryBuilder<Order> queryBuilder)
            : base(context, queryBuilder)
        {
        }
    }
}
