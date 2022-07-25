
using Insurance.Domain;
using System.Threading.Tasks;

namespace Insurance.Service
{
    /// <summary>
    /// Represents the contract service layer for the order's insurance.
    /// </summary>
    public interface IOrderInsuranceService
    {
        /// <summary>
        /// Gets order's total insurance value based on its products.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<OrderInsuranceResponseDto> GetOrderInsuranceAsync(OrderInsuranceRequestDto request);
    }
}
