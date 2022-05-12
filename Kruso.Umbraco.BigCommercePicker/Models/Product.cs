using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kruso.Umbraco.BigCommercePicker.Models
{
    public class Product 
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// User defined product code/stock keeping unit (SKU). 
        /// </summary>
        [JsonProperty(PropertyName = "sku")]
        public string Sku { get; set; }

        /// <summary>
        /// The product description, which can include HTML formatting. 
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// An array of IDs for the categories to which this product belongs. 
        /// </summary>
        [JsonProperty(PropertyName = "categories")]
        public List<int> Categories { get; set; }

        [JsonProperty(PropertyName = "brand_id")]
        public int BrandId { get; set; }

        [JsonProperty(PropertyName = "is_visible")]
        public bool IsVisible { get; set; }

        [JsonProperty(PropertyName = "variants")]
        public IEnumerable<Variant> Variants { get; set; }

    }
}
