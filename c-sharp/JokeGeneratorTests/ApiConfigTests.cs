using JokeGenerator.Config;
using JokeGeneratorTests.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JokeGeneratorTests
{
    [TestClass]
    public class ApiUrlConfigTests
    {

        [TestMethod]
        public void PassingInEmptyConfigurationMakesAllValuesNull()
        {
            var configBuilder = new ConfigurationBuilder();
            var configRoot = configBuilder.Build();

            var apiConfig = new ApiConfig(configRoot);
            
            Assert.IsNull(apiConfig.CategoryApiUrl);
            Assert.IsNull(apiConfig.RandomNameApiUrl);
            Assert.IsNull(apiConfig.JokeApiUrl);
        }
        
        [TestMethod]
        public void PassingInConfigFileBuildsApiConfig()
        {
            var apiConfig = new ApiConfig(ConfigurationInitializer.InitConfiguration());
            
            Assert.AreEqual("https://test.com", apiConfig.CategoryApiUrl);
            Assert.AreEqual("https://test.com", apiConfig.RandomNameApiUrl);
            Assert.AreEqual("https://test.com", apiConfig.JokeApiUrl);
        }
    }
}