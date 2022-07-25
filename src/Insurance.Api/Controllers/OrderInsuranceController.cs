using Insurance.Common;
using Insurance.Domain;
using Insurance.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace Insurance.Api.Controllers
{
    /// <summary>
    /// TODO: add swagger request body description; swagger referenece: https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/213
    /// </summary>
    [Route("api/insurance")]
    [Produces("application/json")]
    public class OrderInsuranceController : Controller
    {
        private readonly ILogger _logger;
        private IOrderInsuranceService _orderInsuranceService;
        

        public OrderInsuranceController(ILogger logger, IOrderInsuranceService orderInsuranceService)
        {
            _logger = logger;
            _orderInsuranceService = orderInsuranceService;
        }

        /// <summary>
        /// Get the order's insurance cost based on its products' sales price.
        /// </summary>
        /// <param name="request">A request of type OrderInsuranceRequestDto</param>
        /// <returns></returns>
        [HttpPost]
        [Route("order/", Name = "Order", Order = 1)]
        [SwaggerOperation(Summary = "Order's insurance", Description = "Gets order's total insurance cost based on its products' sales price")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(OrderInsuranceResponseDto), Description = "Returns the order's total insurance cost")]
        [SwaggerResponse(StatusCodes.Status204NoContent, Description = "This means no products with the given ids were found.")]
        public async Task<IActionResult> GetOrderInsuranceAsync([FromBody]OrderInsuranceRequestDto request)
        {
            var productsInsurance = await _orderInsuranceService.GetOrderInsuranceAsync(request);
            if (productsInsurance == null)
            {
                return NoContent();
            }
            return Ok(productsInsurance);
        }
    }
}
