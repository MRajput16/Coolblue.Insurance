using System.Collections.Generic;

namespace Insurance.Tests
{
    public class InsuranceTestData
    {
        public static IEnumerable<object[]> InsuranceWith1000 = new List<object[]>
        {
            new object[]
            {
                1,
                1000
            }
        };

        public static IEnumerable<object[]> InsuranceWith500 = new List<object[]>
        {
            new object[]
            {
                2,
                500
            }
        };

        public static IEnumerable<object[]> InsuranceWith0 = new List<object[]>
        {
            new object[]
            {
                4,
                0
            }
        };

        public static IEnumerable<object[]> InsuranceWith2000 = new List<object[]>
        {
            new object[]
            {
                5,
                2000
            }
        };

        public static IEnumerable<object[]> InsuranceWith2500 = new List<object[]>
        {
            new object[]
            {
                6,
                2500
            }
        };
    }
}
