using Insurance.Common;
using Insurance.Domain;
using Insurance.Manager;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.Service
{
    public class OrderInsuranceService : IOrderInsuranceService
    {
        private readonly IOrderInsuranceManager _orderInsuranceManager;
        private readonly IProductInsuranceService _productInsuranceService;
        private readonly ILogger _logger;

        public OrderInsuranceService(IOrderInsuranceManager orderInsuranceManager, IProductInsuranceService productInsuranceService, ILogger logger)
        {
            _orderInsuranceManager = orderInsuranceManager;
            _productInsuranceService = productInsuranceService;
            _logger = logger;
        }

        public async Task<OrderInsuranceResponseDto> GetOrderInsuranceAsync(OrderInsuranceRequestDto request)
        {
            var productsInsuranceTasks = new List<Task<ProductInsurance>>();
            foreach (var productId in request.ProductsIds)
            {
                productsInsuranceTasks.Add(_productInsuranceService.GetProductInsuranceDetailsAsync(productId));
            }
            var productsInsurance = await Task.WhenAll(productsInsuranceTasks);

            if (productsInsurance.IsEmpty())
            {
                _logger.LogInformation($"Could not proceed with Get order insurance; products' insurance were null/empty.");
                return null;
            }
            var order = new Order()
            {
                Products = productsInsurance.ToList()
            };

            var totalInsurance = _orderInsuranceManager.CalculateInsurance(order);

            return new OrderInsuranceResponseDto()
            {
                TotalInsuranceValue = totalInsurance
            };
        }
    }
}
