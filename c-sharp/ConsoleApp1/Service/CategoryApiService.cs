using System;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace JokeGenerator.Service
{
    public class CategoryApiService : ApiService, ICategoryApiService
    {
        public CategoryApiService(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            var url = config.GetValue<string>("ApiUrls:Category");
            HttpClient = httpClientFactory.CreateClient();
            HttpClient.BaseAddress = new Uri(url);
        }


        public string[] GetCategories()
        {
            return JsonConvert.DeserializeObject<string[]>(GetRequest());
        }
    }
}