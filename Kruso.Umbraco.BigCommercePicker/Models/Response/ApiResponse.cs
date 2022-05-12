using Newtonsoft.Json;

namespace Kruso.Umbraco.BigCommercePicker.Models.Response
{
    public class ApiResponse
    {
        [JsonProperty(PropertyName = "meta")]
        public Meta Meta { get; set; }

        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }
    }
}
