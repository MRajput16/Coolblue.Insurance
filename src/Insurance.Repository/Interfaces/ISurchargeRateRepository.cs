using Insurance.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insurance.Repository
{
    /// <summary>
    /// contract which represents the operations which the Surcharge with the storage layer
    /// </summary>
    public interface ISurchargeRateRepository
    {
        /// <summary>
        /// Creates the surcharge rates and assign them to the product type id
        /// </summary>
        /// <param name="productTypeSurchargeRate"></param>
        /// <returns></returns>
        Task<ProductTypeSurchargeRate> AddSurchargeRateAsync(ProductTypeSurchargeRate productTypeSurchargeRate);

        /// <summary>
        /// Gets the surcharge rate by its product type id.
        /// </summary>
        /// <param name="productTypeId"></param>
        /// <returns></returns>
        Task<List<SurchargeRate>> GetSurchargeRateAsync(int productTypeId);
    }
}