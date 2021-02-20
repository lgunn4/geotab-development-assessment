using System.Collections.Generic;
using Newtonsoft.Json;

namespace JokeGenerator
{
    public class Joke
    {
        private readonly string _firstName;
        private readonly string _lastName;
        private string _category;
        private readonly ApiService _jokeApiService = new ApiService("https://api.chucknorris.io/jokes/random");

        public Joke()
        {
            ApiService randomNameApiService = new ApiService("https://www.names.privserv.com/api/");
            var result = randomNameApiService.GetRequest();
            
            _firstName = JsonConvert.DeserializeObject<dynamic>(result).name;
            _lastName = JsonConvert.DeserializeObject<dynamic>(result).surname;

        }

        public Joke(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        public void SetCategory(string category)
        {
            _category = category;
        }

        public string GetJoke()
        {
            var jokeResult = "";
            if (_category != null)
            {
                var categoryParameters = new Dictionary<string, string>();
                categoryParameters.Add("category", _category);
                jokeResult =  _jokeApiService.GetRequest(categoryParameters);
            }
            else
            {
                jokeResult = _jokeApiService.GetRequest();
            }
            
            
            var joke = (string) JsonConvert.DeserializeObject<dynamic>(jokeResult).value;
            joke = joke.Replace("Chuck", _firstName);
            joke = joke.Replace("Norris", _lastName);
            
            return joke;
        }
    }
}