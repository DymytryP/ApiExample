using Billing.Infrastructure.Models.Enums;
using Billing.Infrastructure.Models.Orders.RequestData;
using FluentValidation;
using System;
using System.Linq;

namespace Billing.Infrastructure.Validators.Orders
{
    public class OrderRequestDataValidator : AbstractValidator<OrderRequestData>
    {
        public OrderRequestDataValidator()
        {
            decimal minimumAmount = 0.01m;
            decimal maximumAmount = 1000000.00m;
            RuleFor(ord => ord.PayableAmount.Amount)
                .Cascade(CascadeMode.Stop)
                .Must(amount => amount >= minimumAmount)
                .Must(amount => amount <= maximumAmount)
                .WithMessage($"Amount must be between {minimumAmount} and {maximumAmount}.");

            int minimumQuantity = 1;
            int maximumQuantity = 100;
            RuleFor(ord => ord.CartItems)
                .Must(cartItems => cartItems
                    .All(item =>
                        item.Quantity >= minimumQuantity
                        && item.Quantity <= maximumQuantity));

            RuleFor(ord => ord.PaymentGateway)
                .Must(paymentGateway => Enum.GetNames<PaymentGateway>()
                    .Any(name => name == paymentGateway));

            int minimumItemsCount = 1;
            int maximumItemsCount = 10;
            RuleFor(ord => ord.CartItems)
                .Cascade(CascadeMode.Stop)
                .Must(cartItems => cartItems.Count >= minimumItemsCount)
                .Must(cartItems => cartItems.Count <= maximumItemsCount);
        }
    }
}
