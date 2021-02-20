using System.Collections.Generic;
using Newtonsoft.Json;

namespace JokeGenerator
{
    public static class JokeService
    {
        private static string _jokeApiUrl = "https://api.chucknorris.io/jokes/random";
        private static readonly ApiService JokeApiService = new ApiService(_jokeApiUrl);
        
        public static string GetJokeText(Joke joke)
        {
            var jokeResult = "";
            if (joke.GetCategory() != null)
            {
                var categoryParameters = new Dictionary<string, string>();
                categoryParameters.Add("category", joke.GetCategory());
                jokeResult =  JokeApiService.GetRequest(categoryParameters);
            }
            else
            {
                jokeResult = JokeApiService.GetRequest();
            }
            
            
            var jokeText = (string) JsonConvert.DeserializeObject<dynamic>(jokeResult).value;
            jokeText = jokeText.Replace("Chuck", joke.GetFirstName());
            jokeText = jokeText.Replace("Norris", joke.GetLastName());
            
            return jokeText;
        }
    }
}