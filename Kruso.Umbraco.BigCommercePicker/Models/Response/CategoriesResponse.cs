using Newtonsoft.Json;
using System.Collections.Generic;

namespace Kruso.Umbraco.BigCommercePicker.Models.Response
{
    public class CategoriesResponse : ApiResponse
    {
        [JsonProperty(PropertyName = "data")]
        public IEnumerable<Category> Categories { get; set; }
    }
}
