using System;

namespace Insurance.Common
{
    /// <summary>
    /// Custom exception used in case of a product was not found; used mainly while trying to get product by its id.
    /// </summary>
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string message) : base(message)
        {
        }
    }
}
