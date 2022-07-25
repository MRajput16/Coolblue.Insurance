using Insurance.Domain;
using System.Collections.Generic;

namespace Insurance.Tests
{
    public class SurchargeRateTestData
    {
        public static IEnumerable<object[]> ValidSurchargeRates = new List<object[]>
        {
            new object[]
            {
                new SurchargeRateCreateRequestDto()
                {
                    ProductTypeId = 2,
                    SurchareRates = new List<float>(){ 20, 10}
                }
            }
        };

        public static IEnumerable<object[]> InsuranceWithSurchargeRate = new List<object[]>
        {
            new object[]
            {
                20,
                2030,
                new SurchargeRateCreateRequestDto()
                {
                    ProductTypeId = 124,
                    SurchareRates = new List<float>(){ 20, 10}
                }
            }
        };

        public static IEnumerable<object[]> ValidSurchargeRates_ConcurrentUsers = new List<object[]>
        {
            new object[]
            {
                new List<SurchargeRateCreateRequestDto>
                {
                    new SurchargeRateCreateRequestDto()
                    {
                        ProductTypeId = 3,
                        SurchareRates = new List<float>(){ 20, 10}
                    },
                    new SurchargeRateCreateRequestDto()
                    {
                        ProductTypeId = 4,
                        SurchareRates = new List<float>(){ 20, 10}
                    },
                    new SurchargeRateCreateRequestDto()
                    {
                        ProductTypeId = 5,
                        SurchareRates = new List<float>(){ 20, 10}
                    },
                    new SurchargeRateCreateRequestDto()
                    {
                        ProductTypeId = 6,
                        SurchareRates = new List<float>(){ 20, 10}
                    },
                    new SurchargeRateCreateRequestDto()
                    {
                        ProductTypeId = 7,
                        SurchareRates = new List<float>(){ 20, 10}
                    }
                }
            }
        };

    }
}
