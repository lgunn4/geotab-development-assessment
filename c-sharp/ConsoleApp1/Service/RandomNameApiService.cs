using System;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace JokeGenerator.Service
{
    public class RandomNameApiService : ApiService, IRandomNameApiService
    { 
        public RandomNameApiService(IConfiguration config)
        {
            _url = config.GetValue<string>("ApiUrls:RandomName");
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