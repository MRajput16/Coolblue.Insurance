using Insurance.Domain;

namespace Insurance.Operations
{
    /// <summary>
    /// Represents the contract of how the order will calculate its basic insurance value.
    /// </summary>
    public interface IOrderBasicOperation
    {
        float Calculate(Order order);
    }
}
