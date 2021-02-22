using System.Linq;
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
            var json = JsonConvert.SerializeObject(testCategories);
            var factory = HttpClientFactoryMocker.Mock(json);

            var categoryApiService = new CategoryApiService(factory, ConfigurationInitializer.InitConfiguration());
            var returnedCategories = categoryApiService.GetCategories();
            Assert.AreEqual(testCategories.Length, returnedCategories.Length);
            
            foreach (var category in returnedCategories)
            {
                Assert.IsTrue(testCategories.Contains(category));
            }
        }
        
    }
}