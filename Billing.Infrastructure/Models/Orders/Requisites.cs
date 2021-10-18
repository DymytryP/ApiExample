using System;

namespace Billing.Infrastructure.Models.Orders
{
    public record Requisites
    {
        public string Code { get; set; }

        public string Name { get; init; }
    }
}
