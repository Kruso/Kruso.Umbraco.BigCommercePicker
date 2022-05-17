using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Kruso.Umbraco.BigCommercePicker.Models
{
    public class CustomUrl
    {
        /// <summary>
        /// Product URL/slug on the storefront. Starts with / .
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        /// <summary>
        /// True if the URL has been changed from its default state (the auto-assigned URL that BigCommerce provides). 
        /// </summary>
        [JsonProperty(PropertyName = "is_customized")]
        public bool IsCustomized { get; set; }
    }
}
