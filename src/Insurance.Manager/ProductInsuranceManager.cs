using Insurance.Common;
using Insurance.Domain;
using Insurance.Operations;
using Insurance.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.Manager
{
    /// <summary>
    /// concrete implementation of IProductInsuranceManager
    /// </summary>
    public class ProductInsuranceManager : IProductInsuranceManager
    {
        private readonly IBasicInsuranceOperation _basicInsuranceOperation;
        private readonly IExtraInsuranceOperation _extraInsuranceOperation;
        private readonly ISurchargeRateRepository _surchargeRateRepository;
        private readonly ILogger _logger;

        public ProductInsuranceManager(IBasicInsuranceOperation basicInsuranceOperation, IExtraInsuranceOperation extraInsuranceOperation, ILogger logger, ISurchargeRateRepository surchargeRateRepository)
        {
            _basicInsuranceOperation = basicInsuranceOperation;
            _extraInsuranceOperation = extraInsuranceOperation;
            _logger = logger;
            _surchargeRateRepository = surchargeRateRepository;
        }

        /// <summary>
        /// Calculates total product's insurance based on its type's if it's insured or not.
        /// Includes basic insurance operation, special product types' insurance and adding surcharge rates if they exist.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<float> CalculateInsuranceAsync(Product product)
        {
            var salesPrice = product.SalesPrice;
            var productType = product.ProductType;

            var basicInsurance = _basicInsuranceOperation.Calculate(salesPrice);

            var specialAssetsInsurance = _extraInsuranceOperation.Calculate(productType);
            
            var insuranceValueAfterSpecialAssets = basicInsurance + specialAssetsInsurance;

            var surchargeRate = await _surchargeRateRepository.GetSurchargeRateAsync((int)productType);
            var totalSurchargeValue = 0f;
            if (surchargeRate != null)
            {
                totalSurchargeValue = surchargeRate.Select(r => r.Rate).Sum();
            }

            var totalInsuranceValue = insuranceValueAfterSpecialAssets + totalSurchargeValue;
            return totalInsuranceValue;
        }
    }
}
