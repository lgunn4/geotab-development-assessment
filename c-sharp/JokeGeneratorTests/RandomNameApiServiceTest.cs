using System;
using JokeGenerator.Config;
using JokeGenerator.Service;
using JokeGeneratorTests.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JokeGeneratorTests
{
    [TestClass]
    public class RandomNameApiServiceTest
    {

        [TestMethod]
        public void RandomNameApiServiceReturnsRandomNameFromHttpClientRequest()
        {
            var mockResult = "{'name':'John','surname':'Doe','gender':'male','region':'Canada'}";
            var mockName = new Tuple<string, string>("John", "Doe");

            var factory = HttpClientFactoryMocker.Mock(mockResult);
            var config = new ApiConfig(ConfigurationInitializer.InitConfiguration());
            
            var randomNameApiService = new RandomNameApiService(factory, config);
            var name = randomNameApiService.GetRandomName();
            Assert.AreEqual(mockName.Item1, name.Item1);
            Assert.AreEqual(mockName.Item2, name.Item2);
        }
    }
}