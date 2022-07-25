using Insurance.Common;
using Insurance.Domain;
using Insurance.Repository;
using System.Threading.Tasks;

namespace Insurance.Manager
{
    public class SurchargeRateManager : ISurchargeRateManager
    {
        private ILogger _logger;
        private ISurchargeRateRepository _surchargeRateRepository;

        public SurchargeRateManager(ILogger logger, ISurchargeRateRepository surchargeRateRepository)
        {
            _logger = logger;
            _surchargeRateRepository = surchargeRateRepository;
        }

        public async Task<ProductTypeSurchargeRate> CreateSurchargeRateAsync(ProductTypeSurchargeRate productTypeSurchargeRate)
        {
            var surchargeRate = await _surchargeRateRepository.AddSurchargeRateAsync(productTypeSurchargeRate);

            return surchargeRate;
        }
    }
}
