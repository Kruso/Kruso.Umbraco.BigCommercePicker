using Kruso.Umbraco.BigCommercePicker.Models;
using Kruso.Umbraco.BigCommercePicker.Models.Response;
using Kruso.Umbraco.BigCommercePicker.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Umbraco.Cms.Web.BackOffice.Controllers;

namespace Kruso.Umbraco.BigCommercePicker.Controllers
{
    public class BigComResourceController : UmbracoAuthorizedApiController
    {
        private const string ProductFields = "name,sku,width,height,dept,price,id,variants,type,availability,custom_url,categories";
        private const string CategoryFields = "name,id,is_visible,custom_url,parent_id";

        private readonly BigCommerceServiceResolver _bigCommerceServiceResolver;

        public BigComResourceController(BigCommerceServiceResolver bigCommerceServiceResolver)
        {
            _bigCommerceServiceResolver = bigCommerceServiceResolver;
        }

        [HttpPost]
        public async Task<IEnumerable<Product>> GetProductByIds([FromBody] IdsRequest model)
        {
            var bigComService = _bigCommerceServiceResolver.GetService(model.LanguageCode);
            var query = $"?id:in={string.Join(",", model.Ids)}&include=variants&include_fields={ProductFields}";
            var productsResponse = await bigComService.GetProducts(query);

            return productsResponse.Products;
        }

        [HttpGet]
        public async Task<ProductsResponse> GetPagedProduct(
            int pageNumber,
            int pageSize,
            string orderBy = "",
            string orderDirection = "asc",
            string languageCode = null,
            string terms = ""
        )
        {
            var bigComService = _bigCommerceServiceResolver.GetService(languageCode);
            var query = $"?keyword={terms}&keyword_context=merchant&limit={pageSize}&page={pageNumber}&include=variants&include_fields={ProductFields}";
            query += !string.IsNullOrEmpty(orderBy) ? $"&sort={orderBy}&direction={orderDirection}" : "";
            var productsResponse = await bigComService.GetProducts(query);

            return productsResponse;
        }

        [HttpPost]
        public async Task<IEnumerable<Category>> GetCategoryByIds([FromBody] IdsRequest model)
        {
            var bigComService = _bigCommerceServiceResolver.GetService(model.LanguageCode);
            var query = $"?id:in={string.Join(",", model.Ids)}&include_fields={CategoryFields}";
            var categoriesResponse = await bigComService.GetCategories(query);

            return categoriesResponse.Categories;
        }

        [HttpGet]
        public async Task<CategoriesResponse> GetPagedCategory(
            int pageNumber,
            int pageSize,
            string orderBy = "",
            string orderDirection = "asc",
            string languageCode = null,
            string terms = ""
        )
        {
            var bigComService = _bigCommerceServiceResolver.GetService(languageCode);
            var query = $"?keyword={terms}&limit={pageSize}&page={pageNumber}&include_fields={CategoryFields}";
            query += !string.IsNullOrEmpty(orderBy) ? $"&sort={orderBy}&direction={orderDirection}" : "";
            var categoriesResponse = await bigComService.GetCategories(query);

            return categoriesResponse;
        }
    }

    public class IdsRequest
    {
        public int[] Ids { get; set; }
        public string LanguageCode { get; set; }
    }
}
