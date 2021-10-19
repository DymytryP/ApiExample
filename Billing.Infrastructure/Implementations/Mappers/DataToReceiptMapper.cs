using Billing.Infrastructure.Contracts;
using Billing.Infrastructure.Models.BillingUsers;
using Billing.Infrastructure.Models.Orders;
using Billing.Infrastructure.Models.Orders.Receipts;
using System;
using System.Linq;

namespace Billing.Infrastructure.Implementations.Mappers
{
    public class DataToReceiptMapper : IMapper<(OrderDto OrderDto, BillingUserDto BillingUserDto), Receipt>
    {
        /// <summary>
        /// Maps order and billing user data to receipt.
        /// </summary>
        /// <param name="orderAndBillingUserData">Order and billing user data.</param>
        /// <returns>Recept.</returns>
        public Receipt Map((OrderDto OrderDto, BillingUserDto BillingUserDto) orderAndBillingUserData)
        {
            var receipt = new Receipt
            {
                CreatedOn = DateTime.Now,
                CurrencyAmount = orderAndBillingUserData.OrderDto.PayableAmount,
                OrderNumber = orderAndBillingUserData.OrderDto.OrderNumber,
                ReceiptLines = orderAndBillingUserData.OrderDto.OrderLines
                    .Select(ol => new ReceiptLine
                    {
                        Name = ol.Name,
                        Price = ol.Price,
                        Quantity = ol.Quantity
                    })
                    .ToList(),
                Requisites = new Requisites
                {
                    Name = orderAndBillingUserData.BillingUserDto.Name,
                    Code = orderAndBillingUserData.BillingUserDto.Code
                }
            };

            return receipt;
        }
    }
}
