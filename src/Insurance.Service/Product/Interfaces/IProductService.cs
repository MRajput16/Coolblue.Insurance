using Insurance.Domain;
using System.Threading.Tasks;

namespace Insurance.Service
{
    /// <summary>
    /// Represents the contract service layer for the product.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Gets product's details based on its passed product id.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<ProductResponseDto> GetProductAsync(int productId);
    }
}