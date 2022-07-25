using Insurance.Common;
using Insurance.Domain;
using Insurance.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace Insurance.Api.Controllers
{
    [Route("api/insurance")]
    [Produces("application/json")]
    public class SurchargeRateController
    {
        private readonly ILogger _logger;
        private ISurchargeRateService _surchargeRateService;


        public SurchargeRateController(ILogger logger, ISurchargeRateService surchargeRateService)
        {
            _logger = logger;
            _surchargeRateService = surchargeRateService;
        }

        /// <summary>
        /// Adds the surcharge given rates to the given product type.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("surchargerate/", Name = "SurcahrgeRate")]
        [SwaggerOperation(Summary = "Adds Surcharge rates to a product type's insurance", Description = "Add the given surchage rates to the given product type's sales price in case the product type is insured.")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Returns the added surchage rates; which is the given surchagre rates")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "This means that the request has invalid data.")]
        public async Task<IActionResult> CreateSurchargeRateAsync([FromBody] SurchargeRateCreateRequestDto request)
        {
            var surchargeRateCreateResponse = await _surchargeRateService.CreateSurchargeRateAsync(request);
            return new OkObjectResult(surchargeRateCreateResponse);
        }
    }
}
