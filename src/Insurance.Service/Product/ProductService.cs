using Insurance.Common;
using Insurance.Domain;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Insurance.Service
{
    public class ProductService : IProductService
    {
        private static HttpClient ProductClient;
        private ILogger _logger;
        private IConfiguration _configuration;

        public ProductService(IConfiguration configuration, ILogger logger)
        {
            _logger = logger;
            _configuration = configuration;

            if(ProductClient == null)//hint: used a non-static constructor because of the DI
            {
                ProductClient = new HttpClient();
                ProductClient.BaseAddress = new Uri(configuration["Product:ServiceUrl"]);
            }
        }

        public async Task<ProductResponseDto> GetProductAsync(int productId)
        {
            var GetSingleProductEndpoint = _configuration["Product:GetSingleProduct"];
            _logger.LogInformation($"Attmpt to get Product[{productId}] details.");

            GetSingleProductEndpoint = GetSingleProductEndpoint.Replace("{id}", productId.ToString());

            var result = await ProductClient.GetAsync(GetSingleProductEndpoint);
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return null;
            }

            var productDetailsResponse =  await result.Content.ReadAsStringAsync();
            var productDetails = JsonConvert.DeserializeObject<ProductResponseDto>(productDetailsResponse);
            if (productDetails == null)
            {
                _logger.LogInformation($"Product[{productId}] details was not found.");
                return null;
            }
            
            _logger.LogInformation($"Succeeded status code[{result.StatusCode}], get Product[{productId}] details.");

            return productDetails;
        }
    }
}
