using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Kruso.Umbraco.BigCommercePicker.Models
{
    public class Variant 
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "product_id")]
        public int ProductId { get; set; }

        [JsonProperty(PropertyName = "sku")]
        public string Sku { get; set; }

    }
}
