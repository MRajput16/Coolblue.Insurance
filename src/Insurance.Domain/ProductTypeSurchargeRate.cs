using System;
using System.Collections.Generic;

namespace Insurance.Domain
{
    public class ProductTypeSurchargeRate
    {
        public int ProductTypeId { get; set; }
        public List<SurchargeRate> SurchargeRates { get; set; }
    }
}
