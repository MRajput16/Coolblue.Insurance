using System;

namespace Insurance.Common
{
    /// <summary>
    /// Custom exception used in case of failed to create a surcharge rate.
    /// </summary>
    public class CreateSurchareRateException : Exception
    {
        public CreateSurchareRateException(string message) : base(message)
        {
        }
    }
}
