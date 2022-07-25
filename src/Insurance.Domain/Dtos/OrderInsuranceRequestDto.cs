
using Insurance.Domain.ValidationExtension;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Insurance.Domain
{
    public class OrderInsuranceRequestDto
    {
        [JsonPropertyName("productsIds")]
        [Required]
        [CannotBeEmtyList]
        public IList<int> ProductsIds { get; set; }
    }
}
