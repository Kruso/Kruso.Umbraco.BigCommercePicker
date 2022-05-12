using Newtonsoft.Json;

namespace Kruso.Umbraco.BigCommercePicker.Models.Response
{
    public class Meta
    {
        [JsonProperty(PropertyName = "pagination")]
        public Pagination Pagination { get; set; }
    }
}
