using System.Collections.Generic;

namespace Billing.Infrastructure.Models.Orders
{
    public record OrderDto
    {
        public long BillingUserId { get; init; }

        public string Description { get; init; }

        public List<OrderLineDto> OrderLines { get; init; }

        public string OrderNumber { get; init; }

        public CurrencyAmount PayableAmount { get; init; }

        public string PaymentProvider { get; init; }
    }
}
