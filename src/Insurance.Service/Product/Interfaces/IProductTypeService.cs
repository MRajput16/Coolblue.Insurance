using Insurance.Domain;
using System.Threading.Tasks;

namespace Insurance.Service
{
    /// <summary>
    /// Represents the contract service layer for the product type.
    /// </summary>
    public interface IProductTypeService
    {
        /// <summary>
        /// Gets product type's details based on its passed product type id.
        /// </summary>
        /// <param name="productTypeId"></param>
        /// <returns></returns>
        Task<ProductTypeResponseDto> GetProductTypeAsync(int productTypeId);

        /// <summary>
        /// Checks if the passed product type id exists.
        /// </summary>
        /// <param name="productTypeId"></param>
        /// <returns></returns>
        Task<bool> IsProductTypeIdExistsAsync(int productTypeId);
    }
}