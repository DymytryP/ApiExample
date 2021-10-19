using Billing.Infrastructure.Configuration;
using Billing.Infrastructure.Models.Enums;
using Billing.Infrastructure.Models.Orders.RequestData;
using FluentValidation;
using System;
using System.Linq;

namespace Billing.Infrastructure.Validators.Orders
{
    public class OrderRequestDataValidator : AbstractValidator<OrderRequestData>
    {
        /// <summary>
        /// Creates validator object and sets rules for validation.
        /// </summary>
        /// <param name="configuration">The billing API configuration.</param>
        public OrderRequestDataValidator(IBillingApiConfiguration configuration) : base()
        {
            RuleFor(ord => ord.PayableAmount.Amount)
                .Cascade(CascadeMode.Stop)
                .Must(amount => amount >= configuration.MinimumOrderAmount)
                .Must(amount => amount <= configuration.MaximumOrderAmount)
                .WithMessage($"Amount must be between {configuration.MinimumOrderAmount}" +
                    $" and {configuration.MaximumOrderAmount}.");

            RuleFor(ord => ord.CartItems)
                .Must(cartItems => cartItems
                    .All(item =>
                        item.Quantity >= configuration.MinimumProductsQuantity
                        && item.Quantity <= configuration.MaximumProductsQuantity));

            RuleFor(ord => ord.PaymentProvider)
                .Must(paymentGateway => Enum.GetNames<PaymentProvider>()
                    .Any(name => name == paymentGateway));

            RuleFor(ord => ord.CartItems)
                .Cascade(CascadeMode.Stop)
                .Must(cartItems => cartItems.Count >= configuration.MinimumCartItemsCount)
                .Must(cartItems => cartItems.Count <= configuration.MaximumCartItemsCount);
        }
    }
}
