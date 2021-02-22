using System;
using System.Net.Http;
using JokeGenerator.Config.Interface;
using JokeGenerator.Service.Interface;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace JokeGenerator.Service
{
    public class RandomNameApiService : ApiService, IRandomNameApiService
    { 
        public RandomNameApiService(IHttpClientFactory httpClientFactory, IApiConfig apiConfig)
        {
            var url = apiConfig.RandomNameApiUrl;
            HttpClient = httpClientFactory.CreateClient();
            HttpClient.BaseAddress = new Uri(url);
        }

        public Tuple<string, string> GetRandomName()
        {
            var result = GetRequest();
            string firstName = JsonConvert.DeserializeObject<dynamic>(result).name;
            string lastName = JsonConvert.DeserializeObject<dynamic>(result).surname;

            return new Tuple<string, string>(firstName, lastName);
        }
    }

}