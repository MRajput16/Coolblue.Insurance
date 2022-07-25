using System;

namespace Insurance.Common
{
    /// <summary>
    /// Custom exception used in case of a product type was not found; used mainly while trying to get product type by its id.
    /// </summary>
    public class ProductTypeNotFoundException : Exception
    {
        public ProductTypeNotFoundException(string message) : base(message)
        {
        }
    }
}
