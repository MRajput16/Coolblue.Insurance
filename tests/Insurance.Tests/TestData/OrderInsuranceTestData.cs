using Insurance.Domain;
using System.Collections.Generic;

namespace Insurance.Tests
{
    public class OrderInsuranceTestData
    {
        /// <summary>
        ///4 products; laptops and smartphones. 
        ///Their sales price are below 500; each will have 500 insurance cost
        ///Results 2000
        /// </summary>
        public static IEnumerable<object[]> ProductsPriceBelow500 = new List<object[]>
        {
            new object[]
            {
                new OrderInsuranceRequestDto()
                {
                    ProductsIds = new List<int>{7, 8, 9, 10 }
                },
                2000
            }
        };

        /// <summary>
        ///3 products; laptops and smartphones. 
        ///Their sales price are between 500 and 2000; each will have 1000 + 500 insurance cost
        ///Results 4500
        /// </summary>
        public static IEnumerable<object[]> ProductsPriceBetween500And2000 = new List<object[]>
        {
            new object[]
            {
                new OrderInsuranceRequestDto()
                {
                    ProductsIds = new List<int>{11, 12, 13 }
                },
                4500
            }
        };

        /// <summary>
        ///2 products; laptop and smartphone. 
        ///Their sales price are above 2000; each will have 2000 + 500 insurance cost
        ///Results 5000
        /// </summary>
        public static IEnumerable<object[]> ProductsPriceAbove2000 = new List<object[]>
        {
            new object[]
            {
                new OrderInsuranceRequestDto()
                {
                    ProductsIds = new List<int>{14, 15 }
                },
                5000
            }
        };

        /// <summary>
        ///3 products; 2 laptops and 2 digital cameras.
        ///Their sales price are above 2000; each laptops will have 2000 + 500 insurance cost, and each digital camera will have 2000.
        ///Add to total insurance 500Euros because number of cameras is > 1
        ///Results 9500
        /// </summary>
        public static IEnumerable<object[]> ProductsWithTwoCamerasAndLaptposPriceAbove2000 = new List<object[]>
        {
            new object[]
            {
                new OrderInsuranceRequestDto()
                {
                    ProductsIds = new List<int>{16, 16, 17, 17 }
                },
                9500
            }
        };

        /// <summary>
        ///4 laptop products.
        ///Their sales price are above 2000; each laptops will have 2000 + 500 insurance cost.
        ///Results 10000
        /// </summary>
        public static IEnumerable<object[]> ProductsLaptposPriceAbove2000 = new List<object[]>
        {
            new object[]
            {
                new OrderInsuranceRequestDto()
                {
                    ProductsIds = new List<int>{16, 16, 16, 16}
                },
                10000
            }
        };

        /// <summary>
        ///4 laptop products.
        ///Their sales price are above 2000; each laptops will have 2000 + 500 insurance cost.
        ///Results 10000
        /// </summary>
        public static IEnumerable<object[]> ProductsNoInsurance = new List<object[]>
        {
            new object[]
            {
                new OrderInsuranceRequestDto()
                {
                    ProductsIds = new List<int>{18, 18, 18, 18}
                },
                0
            }
        };

        /// <summary>
        ///4 laptop products.
        ///Their sales price are above 2000; each laptops will have 2000 + 500 insurance cost.
        ///Results 10000
        /// </summary>
        public static IEnumerable<object[]> CamerasProductNoInsurance = new List<object[]>
        {
            new object[]
            {
                new OrderInsuranceRequestDto()
                {
                    ProductsIds = new List<int>{19, 19}
                },
                0
            }
        };
    }
}
