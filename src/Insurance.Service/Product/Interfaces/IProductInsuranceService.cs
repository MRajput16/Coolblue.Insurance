using Insurance.Domain;
using System.Threading.Tasks;

namespace Insurance.Service
{
    /// <summary>
    /// Represents the contract service layer for calculating product's total insurance.
    /// </summary>
    public interface IProductInsuranceService
    {
        /// <summary>
        /// Retrieves the insurance cost of the given product's id.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<InsuranceResponseDto> GetProductInsuranceAsync(int productId);

        /// <summary>
        /// Retrieves detailed information about the product including its insurance.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<ProductInsurance> GetProductInsuranceDetailsAsync(int productId);
    }
}
