using System;

namespace Insurance.Common
{
    /// <summary>
    /// Custom exception used while trying to add a product type's surcharge rates again.
    /// </summary>
    public class ProductTypeAlreadyHasSurchargeRateException : Exception
    {
        public ProductTypeAlreadyHasSurchargeRateException(string message) : base(message)
        {
        }
    }
}
