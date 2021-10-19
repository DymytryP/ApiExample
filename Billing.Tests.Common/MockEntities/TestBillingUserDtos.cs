using Billing.Infrastructure.Models.BillingUsers;

namespace Billing.Tests.Common.MockEntities
{
    public static class TestBillingUserDtos
    {
        public static BillingUserDto BillingUserDto_UserId1 =
            new BillingUserDto
            {
                Code = "000000-00000",
                Name = "Test user"
            };
    }
}
