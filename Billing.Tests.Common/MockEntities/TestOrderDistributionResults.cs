using Billing.Data.Models;
using Billing.Infrastructure.Models.Enums;
using Billing.Infrastructure.Models.Orders;

namespace Billing.Tests.Common.MockEntities
{
    public static class TestOrderDistributionResults
    {
        public static OrderDistributionResult OrderDistributionResult =
            new OrderDistributionResult
            {
                DatabaseSaveOperationResult = DatabaseSaveOperationResult.Success,
                PaymentResponseType = PaymentGatewayResponse.Success
            };
    }
}
