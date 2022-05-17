using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Kruso.Umbraco.BigCommercePicker.Models
{
    public class ProductImage
    {
        [JsonProperty(PropertyName = "url_zoom")]
        public string UrlZoom { get; set; }

        [JsonProperty(PropertyName = "url_standard")]
        public string UrlStandard { get; set; }

        [JsonProperty(PropertyName = "url_thumbnail")]
        public string UrlThumbnail { get; set; }

        [JsonProperty(PropertyName = "url_tiny")]
        public string UrlTiny { get; set; }

        /// <summary>
        /// Flag for identifying whether the image is used as the product's thumbnail. 
        /// </summary>
        [JsonProperty(PropertyName = "is_thumbnail")]
        public bool? IsThumbnail { get; set; }

        /// <summary>
        /// The order in which the image will be displayed. Higher integers give the image a lower priority.
        /// </summary>
        [JsonProperty(PropertyName = "sort_order")]
        public int? SortOrder { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}
