using Billing.Infrastructure.Contracts;
using Billing.Infrastructure.Models.Orders.RequestData;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.Api.Controllers
{
    /// <summary>
    /// The billing API order controller.
    /// </summary>
    [Route("api/orders")]
    [ApiController]
    public class OrderPostController : PostController<OrderRequestData>
    {
        /// <summary>
        /// Initializes the instance of OrderController.
        /// </summary>
        /// <param name="orderProcessor"></param>
        public OrderPostController(
            IRequestPipeline<OrderRequestData> requestPipeline,
            AbstractValidator<OrderRequestData> requestValidationRules) : base(requestPipeline, requestValidationRules)
        {
        }

        [Route("postOrder")]
        public async override Task<IActionResult> Process(OrderRequestData requestData)
        {
            return await base.Process(requestData);
        }

        [Route("postOrders")]
        public async override Task<IActionResult> Process(IEnumerable<OrderRequestData> requestData)
        {
            return await base.Process(requestData);
        }
    }
}
