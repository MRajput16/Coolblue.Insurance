using Insurance.Common;
using Insurance.Domain;
using Insurance.Manager;
using System.Threading.Tasks;

namespace Insurance.Service
{
    public class ProductInsuranceService : IProductInsuranceService
    {
        private ILogger _logger;
        private IProductTypeService _productTypeService;
        private IProductService _productService;
        private IProductInsuranceManager _productInsuranceManager;


        public ProductInsuranceService(IProductTypeService productTypeService, IProductService productService, IProductInsuranceManager productInsuranceManager, ILogger logger)
        {
            _logger = logger;
            _productTypeService = productTypeService;
            _productService = productService;
            _productInsuranceManager = productInsuranceManager;
        }

        public async Task<InsuranceResponseDto> GetProductInsuranceAsync(int productId)
        {
            var productInsurance = await GetProductInsuranceDetailsAsync(productId);

            return new InsuranceResponseDto() 
            {
                InsuranceValue = productInsurance.InsuranceValue,
                ProductId = productId
            };
        }


        public async Task<ProductInsurance> GetProductInsuranceDetailsAsync(int productId)
        {
            var productDetails = await _productService.GetProductAsync(productId);
            if (productDetails == null)
            {
                throw new ProductNotFoundException($"Could not proceed with Get product's insurance; product[{productId}] was not found.");
            }

            var productType = await _productTypeService.GetProductTypeAsync(productDetails.ProductTypeId);
            if (productType == null)
            {
                throw new ProductTypeNotFoundException($"Could not proceed with Get product insurance; productType[{productDetails.ProductTypeId}] was not found.");
            }

            var product = new Product()
            {
                Id = productDetails.Id,
                ProductType = (ProductType)productDetails.ProductTypeId,
                SalesPrice = productDetails.SalesPrice,
                IsInsured = productType.CanBeInsured,
            };

            float insuranceValue = await _productInsuranceManager.CalculateInsuranceAsync(product);

            return new ProductInsurance()
            {
                Id = product.Id,
                IsInsured = product.IsInsured,
                ProductType = product.ProductType,
                SalesPrice = product.SalesPrice,
                InsuranceValue = insuranceValue,
            };
        }
    }
}
