using Billing.Data.Models;
using Billing.Infrastructure.Models.Enums;

namespace Billing.Infrastructure.Models.Orders
{
    public record OrderDistributionResult
    {
        public PaymentGatewayResponse PaymentResponseType { get; set; }

        public DatabaseSaveOperationResult DatabaseSaveOperationResult { get; set; }
    }
}
