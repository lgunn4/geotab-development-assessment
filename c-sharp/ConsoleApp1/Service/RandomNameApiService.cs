using System;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace JokeGenerator.Service
{
    public class RandomNameApiService : IRandomNameApiService
    {
        private readonly ApiService _randomNameApi;
        public RandomNameApiService(IConfiguration config)
        {
            _randomNameApi = new ApiService(config.GetValue<string>("ApiUrls:RandomName"));
        }

        public Tuple<string, string> GetRandomName()
        {
            var result = _randomNameApi.GetRequest();
            string firstName = JsonConvert.DeserializeObject<dynamic>(result).name;
            string lastName = JsonConvert.DeserializeObject<dynamic>(result).surname;

            return new Tuple<string, string>(firstName, lastName);
        }
    }

}