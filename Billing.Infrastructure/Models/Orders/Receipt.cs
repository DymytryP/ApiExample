using System;

namespace Billing.Infrastructure.Models.Orders
{
    public record Receipt
    {
        public DateTime CreatedOn { get; init; }

        public CurrencyAmount CurrencyAmount { get; init; }

        public string OrderNumber { get; init; }

        public Requisites Requisites { get; init; }
    }
}
