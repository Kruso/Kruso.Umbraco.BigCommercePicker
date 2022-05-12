using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Kruso.Umbraco.BigCommercePicker.Models
{
    public class Category
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// If the product should be displayed to customers. 
        /// </summary>
        [JsonProperty(PropertyName = "is_visible")]
        public bool IsVisible { get; set; }

    }
}
