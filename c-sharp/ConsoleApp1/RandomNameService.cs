using System;
using Newtonsoft.Json;

namespace JokeGenerator
{
    public static class RandomNameService
    {
        private static string _randomNameApiUrl = "https://www.names.privserv.com/api/";
        private static readonly ApiService RandomNameApi = new ApiService(_randomNameApiUrl);

        public static Tuple<string, string> GetRandomName()
        {
            var result = RandomNameApi.GetRequest();
            string firstName = JsonConvert.DeserializeObject<dynamic>(result).name;
            string lastName = JsonConvert.DeserializeObject<dynamic>(result).surname;

            return new Tuple<string, string>(firstName, lastName);
        }
    }

}