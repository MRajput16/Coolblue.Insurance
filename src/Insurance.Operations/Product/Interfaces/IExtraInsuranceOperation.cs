using Insurance.Domain;

namespace Insurance.Operations
{
    /// <summary>
    /// Contract which represents how any additional/extra product's insurance operation will behave.
    /// </summary>
    public interface IExtraInsuranceOperation
    {
        float Calculate(ProductType productType);
    }
}
