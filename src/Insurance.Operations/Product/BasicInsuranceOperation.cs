namespace Insurance.Operations
{
    public class BasicInsuranceOperation : IBasicInsuranceOperation
    {
        /// <summary>
        /// Calculates insurance according to the product's sales price:
        /// if sales price < 500 (and not inclusive) insurance will be 0.
        /// if sales price >= 500 and < 2000 (and not inclusive) insurance will be 1000
        /// if sales price >= 2000 insurance will be 2000
        /// </summary>
        /// <param name="salesPrice"></param>
        /// <returns></returns>
        public float Calculate(float salesPrice)
        {
            float insuranceValue = 0;

            switch (salesPrice)
            {
                case float n when n < 500:
                    insuranceValue = 0;
                    break;

                case float n when n >= 500 && n < 2000:
                    insuranceValue = 1000;
                    break;

                case float n when n >= 2000:
                    insuranceValue = 2000;
                    break;

                default:
                    break;
            }

            return insuranceValue;
        }
    }
}
