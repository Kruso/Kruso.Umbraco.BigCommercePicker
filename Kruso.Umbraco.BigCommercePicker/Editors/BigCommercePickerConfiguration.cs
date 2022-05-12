using System.Runtime.Serialization;
using Umbraco.Cms.Core.PropertyEditors;

namespace Kruso.Umbraco.BigCommercePicker.Editors
{
    public class BigCommercePickerConfiguration
    {
        public BigCommercePickerConfiguration()
        {
            // initialize defaults
           // PageSize = 20;
           // OrderBy = "Name";
           // OrderDirection = "asc";
        }

        [ConfigurationField("entityType", "Entity Type", BigCommercePickerConstants.AppPluginFolderPath + "/PropertyEditors/EntityTypePicker.html", Description = "")]
        public string EntityType { get; set; } = Kruso.Umbraco.BigCommercePicker.Editors.EntityType.Product.ToString();

        [ConfigurationField("validationLimit", "Amount", "numberrange", Description = "Set a required range of items selected")]
        public NumberRange ValidationLimit { get; set; } = new NumberRange();

        //[ConfigurationField("pageSize", "Page Size", "number", Description = "Number of items per page in picker")]
        //public int PageSize { get; set; }

        //[ConfigurationField("orderBy", "Order By", BigCommercePickerConstants.AppPluginFolderPath + "/PropertyEditors/OrderByPicker.html",
        //    Description = "The default sort order for the list in the picker")]
        //public string OrderBy { get; set; }

        //[ConfigurationField("orderDirection", "Order Direction", "views/propertyeditors/listview/orderdirection.prevalues.html")]
        //public string OrderDirection { get; set; }

        [DataContract]
        public class NumberRange
        {
            [DataMember(Name = "min")]
            public int? Min { get; set; }

            [DataMember(Name = "max")]
            public int? Max { get; set; }
        }
    }
}
