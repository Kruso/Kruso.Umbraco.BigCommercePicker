using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kruso.Umbraco.BigCommercePicker.Models.Response
{
    public class ProductsResponse : ApiResponse
    {
        [JsonProperty(PropertyName = "data")]
        public IEnumerable<Product> Products { get; set; }
    }
}
