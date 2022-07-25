using Insurance.Common;
using Insurance.Domain;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Insurance.Service
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IConfiguration _configuration;
        private static HttpClient ProductTypeClient;
        private ILogger _logger;

        public ProductTypeService(IConfiguration configuration, ILogger logger)
        {
            _logger = logger;
            _configuration = configuration;

            if (ProductTypeClient == null)//hint: used a non-static constructor because of the DI
            {
                ProductTypeClient = new HttpClient();
                ProductTypeClient.BaseAddress = new Uri(configuration["ProductType:ServiceUrl"]);
            }
        }

        public async Task<ProductTypeResponseDto> GetProductTypeAsync(int productTypeId)
        {
            var GetSingleProductTypeEndpoint = _configuration["ProductType:GetSingleProductType"];

            _logger.LogInformation($"Attmpt to get ProductType[{productTypeId}] details.");

            GetSingleProductTypeEndpoint = GetSingleProductTypeEndpoint.Replace("{id}", productTypeId.ToString());
            var result = await ProductTypeClient.GetAsync(GetSingleProductTypeEndpoint);
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return null;
            }
            var productTypeDetailsResponse = await result.Content.ReadAsStringAsync();
            var productTypeDetails = JsonConvert.DeserializeObject<ProductTypeResponseDto>(productTypeDetailsResponse);
            if (productTypeDetails == null)
            {
                _logger.LogInformation($"ProductType[{productTypeId}] details was not found.");
                return null;
            }

            _logger.LogInformation($"Succeeded; status code[{result.StatusCode}], get ProductType[{productTypeId}] details.");

            return productTypeDetails;
        }

        public async Task<bool> IsProductTypeIdExistsAsync(int productTypeId)
        {
            var productType = await GetProductTypeAsync(productTypeId);
            return productType != null;
        }
    }
}
