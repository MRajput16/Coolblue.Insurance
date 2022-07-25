using System.Text.Json.Serialization;

namespace Insurance.Domain
{
    public class ProductResponseDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("productTypeId")]
        public int ProductTypeId { get; set; }

        [JsonPropertyName("salesPrice")]
        public float SalesPrice { get; set; }
    }
}
