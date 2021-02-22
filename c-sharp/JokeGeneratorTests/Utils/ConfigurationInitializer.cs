using Microsoft.Extensions.Configuration;

namespace JokeGeneratorTests.Utils
{
    public static class ConfigurationInitializer
    {
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .Build();

            return config;
        }
    }
}