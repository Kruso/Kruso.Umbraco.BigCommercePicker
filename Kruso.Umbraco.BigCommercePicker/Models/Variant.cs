using System.Collections.Generic;
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

        [JsonProperty(PropertyName = "image_url")]
        public string ImageUrl { get; set; }

        [DataMember(Name = "price", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "price")]
        public double? Price { get; set; }

        /// <summary>
        /// This variant's sale price on the storefront.
        /// </summary>
        [JsonProperty(PropertyName = "sale_price")]
        public double? SalePrice { get; set; }

        [JsonProperty(PropertyName = "option_values")]
        public IEnumerable<VariantOptionValue> OptionValues { get; set; }
    }
}
