using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Kruso.Umbraco.BigCommercePicker.Models.Response;
using Newtonsoft.Json;

namespace Kruso.Umbraco.BigCommercePicker.Services
{
    public class BigCommerceService
    {
        private readonly HttpClient _httpClient;
        protected static JsonSerializerSettings _serializerSettings;

        public BigCommerceService(IHttpClientFactory httpClientFactory, string storeHash, string token)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri($"https://api.bigcommerce.com/stores/{storeHash}/v3/catalog/");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("x-auth-token", token);

            _serializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        public async Task<ProductsResponse> GetProducts(string queryString = "")
        {
            var pathAndQuery = $"products{queryString}";
            return await SendAsync<ProductsResponse>(HttpMethod.Get, pathAndQuery);
        }

        public async Task<CategoriesResponse> GetCategories(string queryString = "")
        {
            var pathAndQuery = $"categories{queryString}";
            return await SendAsync<CategoriesResponse>(HttpMethod.Get, pathAndQuery);
        }

        public async Task<BrandsResponse> GetBrands(string queryString = "")
        {
            var pathAndQuery = $"brands{queryString}";
            return await SendAsync<BrandsResponse>(HttpMethod.Get, pathAndQuery);
        }


        private async Task<TResult> SendAsync<TResult>(HttpMethod httpMethod, string pathAndQuery, object model = null, CancellationToken cancellationToken = default) where TResult : class
        {
            var requestMessage = new HttpRequestMessage(httpMethod, pathAndQuery);
            if (model != null)
            {
                var modelAsString = new StringContent(JsonConvert.SerializeObject(model, _serializerSettings), Encoding.UTF8, "application/json");
                requestMessage.Content = modelAsString;
            }

            var response = await _httpClient.SendAsync(requestMessage, cancellationToken);
            var stream = await response.Content.ReadAsStreamAsync(cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                return DeserializeJsonFromStream<TResult>(stream);
            }
            else
            {
                var content = await StreamToStringAsync(stream);
                throw new ApiException(content)
                {
                    StatusCode = (int)response.StatusCode,
                };
            }
        }

        private static T DeserializeJsonFromStream<T>(Stream stream)
        {
            if (stream.CanRead == false)
                return default(T);

            using var streamReader = new StreamReader(stream);
            using var jsonTextReader = new JsonTextReader(streamReader);
            var jsonSerializer = new JsonSerializer();
            var result = jsonSerializer.Deserialize<T>(jsonTextReader);
            return result ?? default(T);
        }

        private static async Task<string> StreamToStringAsync(Stream stream)
        {
            using var sr = new StreamReader(stream);
            var content = await sr.ReadToEndAsync();
            return content;
        }
    }

    public class ApiException : Exception
    {
        public int StatusCode { get; set; }

        public ApiException(string message) : base(message) { }
    }
}
