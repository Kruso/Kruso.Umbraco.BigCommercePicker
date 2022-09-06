using System;
using System.Collections.Generic;
using System.Linq;
using Kruso.Umbraco.BigCommercePicker.Models;
using Kruso.Umbraco.BigCommercePicker.Services;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors;

namespace Kruso.Umbraco.BigCommercePicker.Editors
{
    public class BigCommercePickerValueConverter : PropertyValueConverterBase
    {
        private readonly BigCommerceServiceResolver _bigCommerceServiceResolver;
        private readonly IVariationContextAccessor _variationContextAccessor;
        private const string ProductFields = "name,sku,weight,width,height,dept,price,id,type,availability,custom_url,images,variants,is_visible";
        private const string CategoryFields = "name,id,is_visible,custom_url";

        public BigCommercePickerValueConverter(BigCommerceServiceResolver bigCommerceServiceResolver, IVariationContextAccessor variationContextAccessor)
        {
            _bigCommerceServiceResolver = bigCommerceServiceResolver;
            _variationContextAccessor = variationContextAccessor;
        }

        public override bool IsConverter(IPublishedPropertyType propertyType)
            => propertyType.EditorAlias == BigCommercePickerConstants.PropertyEditors.PickerAlias;

        public override Type GetPropertyValueType(IPublishedPropertyType propertyType)
        {
            var isMultiPicker = IsMultiPicker(propertyType);
            var entityType = GetEntityType(propertyType);

            if (entityType == EntityType.Category)
            {
                return isMultiPicker ? typeof(IEnumerable<Category>) : typeof(Category);
            }
            else if (entityType == EntityType.Product)
            {
                return isMultiPicker ? typeof(IEnumerable<Product>) : typeof(Product);
            }

            return typeof(object);
        }

        public override PropertyCacheLevel GetPropertyCacheLevel(IPublishedPropertyType propertyType)
            => PropertyCacheLevel.Snapshot;

        public override object ConvertSourceToIntermediate(IPublishedElement owner, IPublishedPropertyType propertyType, object source, bool preview)
        {
            if (source == null) return null;

            var entityIds = source.ToString()
                .Split(new [] {','}, StringSplitOptions.RemoveEmptyEntries)
                //.Select(Guid.Parse)
                .ToArray();
            return entityIds;
        }

        public override object ConvertIntermediateToObject(IPublishedElement owner, IPublishedPropertyType propertyType, PropertyCacheLevel cacheLevel, object source, bool preview)
        {
            if (source == null)
            {
                return null;
            }

            var entityIds = (string[])source;
            var entityType = GetEntityType(propertyType);
            var isMultiPicker = IsMultiPicker(propertyType);

            if (entityType == EntityType.Category)
            {
                var query = $"?id:in={string.Join(",", entityIds)}&include_fields={CategoryFields}";
                var categoriesResponse = _bigCommerceServiceResolver.GetService(_variationContextAccessor.VariationContext.Culture).GetCategories(query).GetAwaiter().GetResult();
                if (isMultiPicker)
                {
                    return categoriesResponse.Categories;
                }

                return categoriesResponse.Categories.FirstOrDefault();
            }
            else if (entityType == EntityType.Product)
            {
                var query = $"?id:in={string.Join(",", entityIds)}&include=variants,images&include_fields={ProductFields}";
                var productsResponse = _bigCommerceServiceResolver.GetService(_variationContextAccessor.VariationContext.Culture).GetProducts(query).GetAwaiter().GetResult();
                if (isMultiPicker)
                {
                    return productsResponse.Products;
                }

                return productsResponse.Products.FirstOrDefault();
            }

            return null;
        }

        private static bool IsMultiPicker(IPublishedPropertyType propertyType)
        {
            var config = propertyType.DataType.ConfigurationAs<BigCommercePickerConfiguration>();
            var isMultiPicker = !config.ValidationLimit.Max.HasValue || config.ValidationLimit.Max.Value > 1;
            return isMultiPicker;
        }

        private static EntityType GetEntityType(IPublishedPropertyType propertyType)
        {
            var config = propertyType.DataType.ConfigurationAs<BigCommercePickerConfiguration>();
            return (EntityType)Enum.Parse(typeof(EntityType), config.EntityType);
        }
    }
}
