using Billing.Infrastructure.Contracts.Models;
using Billing.Infrastructure.Models.Carts;
using System.Collections.Generic;

namespace Billing.Infrastructure.Models.Orders.RequestData
{
    public record OrderRequestData
    {
        public long BillingUserId { get; init; }

        public string Description { get; init; }

        public string OrderNumber { get; init; }

        public CurrencyAmount PayableAmount { get; init; }

        public string PaymentGateway { get; init; }

        public List<CartItem> CartItems { get; init; }
    }
}
