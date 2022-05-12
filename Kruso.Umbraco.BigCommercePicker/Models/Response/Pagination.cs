using Newtonsoft.Json;

namespace Kruso.Umbraco.BigCommercePicker.Models.Response
{
    public class Pagination
    {
        public int Count { get; set; }

        [JsonProperty(PropertyName = "current_page")]
        public int CurrentPage { get; set; }

        [JsonProperty(PropertyName = "per_page")]
        public int PerPage { get; set; }

        [JsonProperty(PropertyName = "too_many")]
        public bool TooMany { get; set; }

        public int Total { get; set; }

        [JsonProperty(PropertyName = "total_pages")]
        public int TotalPages { get; set; }
    }
}
