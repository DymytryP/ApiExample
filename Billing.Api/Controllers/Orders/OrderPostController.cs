using Billing.Infrastructure.Contracts;
using Billing.Infrastructure.Models.Orders.RequestData;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Orders = Billing.Infrastructure.Models.Orders.Receipts;

namespace Billing.Api.Controllers
{
    /// <summary>
    /// The billing API order controller.
    /// </summary>
    [Route("api/orders")]
    [ApiController]
    public class OrderPostController : PostController<OrderRequestData, Orders.Receipt>
    {
        /// <summary>
        /// Initializes the instance of OrderController.
        /// </summary>
        /// <param name="orderProcessor"></param>
        public OrderPostController(
            IRequestPipeline<OrderRequestData, Orders.Receipt> requestPipeline,
            AbstractValidator<OrderRequestData> requestValidationRules) : base(requestPipeline, requestValidationRules)
        {
        }

        /// <summary>
        /// Processes received order request data.
        /// </summary>
        /// <param name="requestData">The order.</param>
        /// <returns>Receipt as JSON.</returns>
        [Route("postOrder")]
        public async override Task<IActionResult> Process(OrderRequestData requestData)
        {
            return await base.Process(requestData);
        }

        /// <summary>
        /// Not supported. Do not use.
        /// </summary>
        [Route("postOrders")]
        public async override Task<IActionResult> Process(IEnumerable<OrderRequestData> requestData)
        {
            throw new NotImplementedException();
        }
    }
}
