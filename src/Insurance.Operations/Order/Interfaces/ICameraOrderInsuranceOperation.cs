using Insurance.Domain;

namespace Insurance.Operations
{
    /// <summary>
    /// Represents the contract of how the order; which contains cameras, will calculate its extra insurance value.
    /// </summary>
    public interface ICameraOrderInsuranceOperation
    {
        float Calculate(Order order);
    }
}
