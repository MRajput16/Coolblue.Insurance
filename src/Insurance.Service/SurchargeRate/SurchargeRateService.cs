using Insurance.Common;
using Insurance.Domain;
using Insurance.Manager;
using Insurance.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.Service
{
    public class SurchargeRateService : ISurchargeRateService
    {
        private ILogger _logger;
        private IProductTypeService _productTypeService;
        private ISurchargeRateManager _surchargeRateManager;

        public SurchargeRateService(ILogger logger, IProductTypeService productTypeService, ISurchargeRateManager surchargeRateManager)
        {
            _logger = logger;
            _productTypeService = productTypeService;
            _surchargeRateManager = surchargeRateManager;
        }

        public async Task<SurchargeRateCreateResponseDto> CreateSurchargeRateAsync(SurchargeRateCreateRequestDto request)
        {
            var isProductIdExists = await _productTypeService.IsProductTypeIdExistsAsync(request.ProductTypeId);
            if (!isProductIdExists)
            {
                var message = $"ProductTypeId[{request.ProductTypeId}] is not found.";
                _logger.LogError(message);
                throw new SurchargeRateProductTypeNotFoundException(message);
            }
            
            var productTypeSurchargeRate = new ProductTypeSurchargeRate()
            {
                ProductTypeId = request.ProductTypeId,
                SurchargeRates = request.SurchareRates.Select(r => new SurchargeRate() { Rate = r }).ToList()
            };

            var surchargeRate = await _surchargeRateManager.CreateSurchargeRateAsync(productTypeSurchargeRate);

            return new SurchargeRateCreateResponseDto() 
            {
                SurchareRates = surchargeRate.SurchargeRates.Select(r=>r.Rate).ToList(),
                ProductTypeId = surchargeRate.ProductTypeId
            };
        }
    }
}
