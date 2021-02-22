using JokeGenerator.Config.Interface;
using Microsoft.Extensions.Configuration;

namespace JokeGenerator.Config
{
    public class ApiConfig : IApiConfig
    {
        public string JokeApiUrl { get; }
        public string CategoryApiUrl { get; }
        public string RandomNameApiUrl { get; }

        public ApiConfig(IConfiguration config)
        {
            JokeApiUrl = config.GetValue<string>("ApiUrls:Joke");
            CategoryApiUrl = config.GetValue<string>("ApiUrls:Category");
            RandomNameApiUrl = config.GetValue<string>("ApiUrls:RandomName");
        }
    }
}