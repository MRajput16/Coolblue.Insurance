using System.Collections.Generic;

namespace Insurance.Domain
{
    public class SurchargeRateCreateRequestDto
    {
        public int ProductTypeId { get; set; }
        public List<float> SurchareRates { get; set; }
    }
}
