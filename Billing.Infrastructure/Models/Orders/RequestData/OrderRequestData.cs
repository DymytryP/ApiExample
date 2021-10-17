using Billing.Infrastructure.Contracts.Models;

namespace Billing.Infrastructure.Models.Orders.RequestData
{
    public class OrderRequestData : IRequestData
    {
        public long BillingUserId { get; set; }

        public string Description { get; set; }

        public string OrderNumber { get; set; }

        public CurrencyAmount PayableAmount { get; set; }

        public string PaymentGateway { get; set; }
    }
}
