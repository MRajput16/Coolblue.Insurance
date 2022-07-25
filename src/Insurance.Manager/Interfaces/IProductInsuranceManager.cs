using Insurance.Domain;
using System.Threading.Tasks;

namespace Insurance.Manager
{
    /// <summary>
    /// Product insurance calculation manager; encapsulates how the product's insurance is calculated.
    /// </summary>
    public interface IProductInsuranceManager
    {
        /// <summary>
        /// Calculates product's total insurance cost based on some paramters/operations.
        /// </summary>
        /// <param name="product"></param>
        /// <returns>total product's insurance</returns>
        Task<float> CalculateInsuranceAsync(Product product);
    }
}