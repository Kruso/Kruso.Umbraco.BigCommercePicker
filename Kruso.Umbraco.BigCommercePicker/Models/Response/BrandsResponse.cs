using Newtonsoft.Json;
using System.Collections.Generic;

namespace Kruso.Umbraco.BigCommercePicker.Models.Response
{
    public class BrandsResponse : ApiResponse
    {
        [JsonProperty(PropertyName = "data")]
        public IEnumerable<Brand> Brands { get; set; }
    }
}
