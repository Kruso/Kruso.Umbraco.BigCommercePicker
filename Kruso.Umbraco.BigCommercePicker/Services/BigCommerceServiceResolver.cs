using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Kruso.Umbraco.BigCommercePicker.Services
{
    public class BigCommerceServiceResolver
    {
        private Dictionary<string, BigCommerceService> _bigCommerceServices;

        public BigCommerceServiceResolver(IHttpClientFactory httpClientFactory, IEnumerable<BigCommerceServiceConfiguration> serviceConfigurations)
        {
            _bigCommerceServices = new Dictionary<string, BigCommerceService>();
            foreach (var configuration in serviceConfigurations)
            {
                _bigCommerceServices.Add(configuration.LanguageCode ?? string.Empty, new BigCommerceService(httpClientFactory, configuration.StoreHash, configuration.AuthToken));
            }
        }

        /// <summary>
        /// Get BigCommerce service for locale. Fallback to service with empty locale. 
        /// </summary>
        public BigCommerceService GetService(string locale)
        {
            BigCommerceService service = null;
            if (_bigCommerceServices.ContainsKey(locale ?? string.Empty))
            {
                service = _bigCommerceServices[locale ?? string.Empty];
            }
            if (service == null && _bigCommerceServices.ContainsKey(string.Empty))
            {
                service = _bigCommerceServices[string.Empty];
            }

            if (service == null)
                throw new Exception($"No BigCommerce store is defined for locale \"{locale}\".");

            return service;
        }
    }
}
