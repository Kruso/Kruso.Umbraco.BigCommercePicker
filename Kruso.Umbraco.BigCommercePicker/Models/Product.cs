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
        /// The product description, which may be HTML formatted. 
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "categories")]
        public List<int> Categories { get; set; }

        [JsonProperty(PropertyName = "brand_id")]
        public int BrandId { get; set; }

        [JsonProperty(PropertyName = "is_visible")]
        public bool IsVisible { get; set; }

        [JsonProperty(PropertyName = "weight")]
        public float? Weight { get; set; }

        [JsonProperty(PropertyName = "width")]
        public float? Width { get; set; }

        [JsonProperty(PropertyName = "depth")]
        public float? Depth { get; set; }

        [JsonProperty(PropertyName = "height")]
        public float? Height { get; set; }

        /// <summary>
        /// The price may include tax, based on the store settings. 
        /// </summary>
        [JsonProperty(PropertyName = "price")]
        public float? Price { get; set; }

        [JsonProperty(PropertyName = "sale_price")]
        public float? SalePrice { get; set; }

        [JsonProperty(PropertyName = "custom_url")]
        public CustomUrl CustomUrl { get; set; }

        [JsonProperty(PropertyName = "images")]
        public List<ProductImage> Images { get; set; }

        [JsonProperty(PropertyName = "variants")]
        public List<Variant> Variants { get; set; }

    }
}
