using System;

namespace Insurance.Common
{
    /// <summary>
    /// Custom exception used while trying to create a surcharge rate of a not existing product type id.
    /// </summary>
    public class SurchargeRateProductTypeNotFoundException : Exception
    {
        public SurchargeRateProductTypeNotFoundException(string message) : base(message)
        {
        }
    }
}
