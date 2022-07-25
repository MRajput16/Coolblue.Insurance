namespace Insurance.Operations
{
    /// <summary>
    /// Contract which represents how the basic product's insurance operation will behave.
    /// </summary>
    public interface IBasicInsuranceOperation
    {
        float Calculate(float salesPrice);
    }
}
