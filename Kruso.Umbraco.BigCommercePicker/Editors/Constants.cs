namespace Kruso.Umbraco.BigCommercePicker.Editors
{
    public static class BigCommercePickerConstants
    {
        public const string AppPluginFolderPath = "~/App_Plugins/Kruso.Umbraco.BigCommercePicker";

        //public static class Configuration
        //{
        //    public const string ConfigPrefix = "Umbraco:Cms:Integrations:Commerce:CommerceTools:";

        //    public const string Settings = ConfigPrefix + "Settings";
        //}

        public static class PropertyEditors
        {
            public const string PickerAlias = "BigCommerce picker";
        }

    }

    public enum EntityType
    {
        Category,
        Product
    }
}
