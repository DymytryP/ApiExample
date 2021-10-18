using Billing.Data;
using Billing.Data.Contracts;
using Billing.Data.Models.Entities;
using Billing.Data.Queries.Mappings;
using Billing.Data.Repositories;
using Billing.Infrastructure.Contracts;
using Billing.Infrastructure.Models.BillingUsers;
using Billing.Infrastructure.Specifications.BillingUsers;
using System;
using System.Threading.Tasks;

namespace Billing.Infrastructure.Implementations
{
    public class BillingUserDataProvider : Repository<BillingUser>, IDataProvider<long, BillingUserDto>
    {
        public BillingUserDataProvider(BillingDbContext context, IQueryBuilder<BillingUser> queryBuilder)
            : base(context, queryBuilder)
        {
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        public BillingUserDto Get(long billingUserId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets billing user by ID asynchronously.
        /// </summary>
        /// <param name="billingUserId">The billing user ID.</param>
        /// <returns>Billing user DTO.</returns>
        public async Task<BillingUserDto> GetAsync(long billingUserId)
        {
            var idSpecification = new IdSpecification(billingUserId);
            var billingUserEntityToDtoMapping = new Mapping<BillingUser, BillingUserDto>(
                billingUser => new BillingUserDto
                {
                    Code = billingUser.Code,
                    Name = billingUser.Name
                });

            var billingUser = await base.FindFirstAsync(idSpecification, billingUserEntityToDtoMapping);

            return billingUser;
        }
    }
}
