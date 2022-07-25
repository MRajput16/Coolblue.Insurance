using Insurance.Domain;
using System.Linq;

namespace Insurance.Operations
{
    public class CameraOrderInsuranceOperation : ICameraOrderInsuranceOperation
    {

        /// <summary>
        /// Calculates 500Euros if the order cotains more than one insured camera.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public float Calculate(Order order)
        {
            var containsCamerasMoreThanOne = order.Products.Where(p => p.IsInsured && p.ProductType == ProductType.Camera).Count() > 1;
            if (!containsCamerasMoreThanOne)
            {
                return 0;
            }
            return 500;
        }
    }
}
