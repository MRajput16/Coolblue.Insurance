using Insurance.Domain;

namespace Insurance.Operations
{
    public class ExtraInsuranceOperation : IExtraInsuranceOperation
    {
        /// <summary>
        /// Returns 500Euros in case the product type is laptop or smart phone
        /// </summary>
        /// <param name="productType"></param>
        /// <returns></returns>
        public float Calculate(ProductType productType)
        {
            float totalInsurance = 0;
            float extraInsurance = 500;

            switch (productType)
            {
                case ProductType.Laptop:
                    totalInsurance += extraInsurance;
                    break;

                case ProductType.SmartPhone:
                    totalInsurance += extraInsurance;
                    break;

                default:
                    break;
            }

            return totalInsurance;
        }
    }
}
