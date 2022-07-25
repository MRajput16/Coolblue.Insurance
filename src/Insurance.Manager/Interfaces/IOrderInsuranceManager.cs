using Insurance.Domain;

namespace Insurance.Manager
{
    /// <summary>
    /// Order insurance calculation manager; encapsulates how the order insurance is calculated.
    /// </summary>
    public interface IOrderInsuranceManager
    {
        /// <summary>
        /// Calculates order's total insurance cost based on its given products.
        /// </summary>
        /// <param name="order"></param>
        /// <returns>order's total insurance cost</returns>
        float CalculateInsurance(Order order);
    }
}