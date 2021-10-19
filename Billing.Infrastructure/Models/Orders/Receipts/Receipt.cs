using System;
using System.Collections.Generic;

namespace Billing.Infrastructure.Models.Orders.Receipts
{
    public record Receipt
    {
        public DateTime CreatedOn { get; init; }

        public CurrencyAmount CurrencyAmount { get; init; }

        public string OrderNumber { get; init; }

        public List<ReceiptLine> ReceiptLines { get; init; }

        public Requisites Requisites { get; init; }
    }
}
