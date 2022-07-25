using Insurance.Common;
using Insurance.Domain;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insurance.Repository
{
    public class SurchargeRateRepository : ISurchargeRateRepository
    {
        /// <summary>
        /// A concurrent data structure for holding the product type as a key and its corresponding surcharge rates as a value.
        /// reference: https://docs.microsoft.com/en-us/dotnet/standard/collections/thread-safe/how-to-add-and-remove-items
        /// </summary>
        private static ConcurrentDictionary<int, List<SurchargeRate>> _productTypeSurchargeRate;

        static SurchargeRateRepository()
        {
            _productTypeSurchargeRate = new ConcurrentDictionary<int, List<SurchargeRate>>();
        }

        public async Task<ProductTypeSurchargeRate> AddSurchargeRateAsync(ProductTypeSurchargeRate productTypeSurchargeRate)
        {
            var productTypeId = productTypeSurchargeRate.ProductTypeId;

            var isAssigned = await Task.Run(() =>
            {
                if (_productTypeSurchargeRate.ContainsKey(productTypeId))
                {
                    throw new ProductTypeAlreadyHasSurchargeRateException($"ProductTypeId[{productTypeId}] has already its Surcharge rates added");
                }
                var isAdded = _productTypeSurchargeRate.TryAdd(productTypeId, productTypeSurchargeRate.SurchargeRates);
                return isAdded;
            });

            if (!isAssigned)
            {
                throw new CreateSurchareRateException($"Failed to Add surcharge rates to product type id [{productTypeId}].");
            }

            return productTypeSurchargeRate;
        }

        public async Task<List<SurchargeRate>> GetSurchargeRateAsync(int productTypeId)
        {
            return await Task.Run(() => 
            {
                var res = _productTypeSurchargeRate.TryGetValue(productTypeId, out var surchargeRates);
                return res ? surchargeRates : null;
            });
        }
    }
}
