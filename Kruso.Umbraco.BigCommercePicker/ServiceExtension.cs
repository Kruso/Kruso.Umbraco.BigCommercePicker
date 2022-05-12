using Kruso.Umbraco.BigCommercePicker.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Net.Http;

namespace Kruso.Umbraco.BigCommercePicker
{
    public static class ServiceExtension
    {
        public static void AddBigCommercePicker(this IServiceCollection services, IEnumerable<BigCommerceServiceConfiguration> serviceConfigurations)
        {
            services.AddHttpClient<BigCommerceServiceResolver>();
            services.AddSingleton(s => new BigCommerceServiceResolver(s.GetService<IHttpClientFactory>(), serviceConfigurations));
        }
    }
}
