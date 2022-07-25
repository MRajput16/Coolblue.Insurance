using System.Threading.Tasks;
using Insurance.Common;
using Insurance.Domain;
using Insurance.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Insurance.Api.Controllers
{
    [Route("api/insurance")]
    [Produces("application/json")]
    public class ProductInsuranceController : Controller
    {
        private IProductInsuranceService _insuranceService; 
        public ProductInsuranceController(ILogger logger, IProductInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }


        /// <summary>
        /// Get the product's insurance value based on its sales price.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("product/{productId}")]
        [SwaggerOperation(Summary = "Product's insurance", Description = "Gets product's insurance cost based on its sales price")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(InsuranceResponseDto), Description = "Returns the product's insurance cost")]
        [SwaggerResponse(StatusCodes.Status204NoContent, Description = "This means no product with the given id was found.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "This means that the request has invalid data.")]
        public async Task<IActionResult> GetProductInsuranceAsync(int productId)
        {
            var productInsurance = await _insuranceService.GetProductInsuranceAsync(productId);
            if (productInsurance == null)
            {
                return NoContent();
            }
            return Ok(productInsurance);
        }
    }
}
