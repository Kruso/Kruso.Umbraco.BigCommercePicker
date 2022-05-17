using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Kruso.Umbraco.BigCommercePicker.Models
{
    public class VariantOptionValue
    {
        /// <summary>
        /// The name of the option. Ex: Color
        /// </summary>
        [JsonProperty(PropertyName = "option_display_name")]
        public string OptionDisplayName { get; set; }

        /// <summary>
        /// The label of the option value. Ex: Beige
        /// </summary>
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }
    }
}
