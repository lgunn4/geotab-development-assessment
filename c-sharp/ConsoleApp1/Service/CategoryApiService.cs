using System;
using System.Net.Http;
using JokeGenerator.Config.Interface;
using JokeGenerator.Service.Interface;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace JokeGenerator.Service
{
    public class CategoryApiService : ApiService, ICategoryApiService
    {
        public CategoryApiService(IHttpClientFactory httpClientFactory, IApiConfig apiConfig)
        {
            var url = apiConfig.CategoryApiUrl;
            HttpClient = httpClientFactory.CreateClient();
            HttpClient.BaseAddress = new Uri(url);
        }


        public string[] GetCategories()
        {
            return JsonConvert.DeserializeObject<string[]>(GetRequest());
        }
    }
}