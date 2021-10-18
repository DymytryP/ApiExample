using Billing.Data.Models.Entities;
using Billing.Data.Queries.Specification;
using System;
using System.Linq.Expressions;

namespace Billing.Infrastructure.Specifications.BillingUsers
{
    public class IdSpecification : Specification<BillingUser>
    {
        private readonly long id;

        public IdSpecification(long id)
        {
            this.id = id;
        }

        /// <inheritdoc/>
        public override Expression<Func<BillingUser, bool>> ToExpression()
        {
            return billingUser => billingUser.Id == id;
        }
    }
}
