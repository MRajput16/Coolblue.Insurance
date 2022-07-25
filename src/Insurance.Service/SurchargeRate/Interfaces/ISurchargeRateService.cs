using Insurance.Domain;
using System.Threading.Tasks;

namespace Insurance.Service
{
    /// <summary>
    /// Represents the contract service layer for the surcharge rate's insurance.
    /// </summary>
    public interface ISurchargeRateService
    {
        /// <summary>
        /// Creates a surcharge rates and assign them to an already exiting product type if the product type exists.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<SurchargeRateCreateResponseDto> CreateSurchargeRateAsync(SurchargeRateCreateRequestDto request);
    }
}
