using JokeGenerator.Domain;
using JokeGenerator.Service;
using JokeGeneratorTests.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace JokeGeneratorTests
{
    [TestClass]
    public class JokeApiServiceTest
    {

        [TestMethod]
        public void JokeWithNullNameRemainsChuckNorris()
        {
            var resultString = "{'value':'When Chuck Norris breathes there are hurricane warnings'}";
            var originalJoke = (string) JsonConvert.DeserializeObject<dynamic>(resultString).value;

            var config = ConfigurationInitializer.InitConfiguration();
            var factory = HttpClientFactoryMocker.Mock(resultString);
            var service = new JokeApiService(factory, config);

            var joke = new Joke();
            var serviceJokeString = service.GetJokeText(joke);

            Assert.IsTrue(serviceJokeString.Contains("Chuck"));
            Assert.IsTrue(serviceJokeString.Contains("Norris"));
            Assert.AreEqual(originalJoke, serviceJokeString);
        }
        
        
        //Joke with name replaces chuck norris
        
        [TestMethod]
        public void JokeWithNameReplacesChuckNorris()
        {
            var resultString = "{'value':'When Chuck Norris breathes there are hurricane warnings'}";
            var originalJoke = (string) JsonConvert.DeserializeObject<dynamic>(resultString).value;

            var config = ConfigurationInitializer.InitConfiguration();
            var factory = HttpClientFactoryMocker.Mock(resultString);
            var service = new JokeApiService(factory, config);

            var joke = new Joke("Logan", "Gunn");
            var serviceJokeString = service.GetJokeText(joke);

            Assert.IsFalse(serviceJokeString.Contains("Chuck"));
            Assert.IsFalse(serviceJokeString.Contains("Norris"));
            Assert.IsTrue(serviceJokeString.Contains("Logan"));
            Assert.IsTrue(serviceJokeString.Contains("Gunn"));
            Assert.AreNotEqual(originalJoke, serviceJokeString);
        }
    }
}