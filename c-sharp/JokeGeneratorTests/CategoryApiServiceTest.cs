using System.Linq;
using JokeGenerator.Config;
using JokeGenerator.Service;
using JokeGeneratorTests.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace JokeGeneratorTests
{
    [TestClass]
    public class CategoryApiServiceTest
    {

        [TestMethod]
        public void CategoryApiServiceReturnsCategoriesFromHttpClientRequest()
        {
            string[] testCategories = {"test1", "test2", "test3"};
            var testJson = JsonConvert.SerializeObject(testCategories);
            var factory = HttpClientFactoryMocker.Mock(testJson);
            var config = new ApiConfig(ConfigurationInitializer.InitConfiguration());
            var categoryApiService = new CategoryApiService(factory, config);
            
            var returnedCategories = categoryApiService.GetCategories();
            Assert.AreEqual(testCategories.Length, returnedCategories.Length);
            foreach (var category in returnedCategories)
            {
                Assert.IsTrue(testCategories.Contains(category));
            }
        }
        
    }
}