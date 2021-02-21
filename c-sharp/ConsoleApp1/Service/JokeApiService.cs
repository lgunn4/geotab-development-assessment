using System.Collections.Generic;
using JokeGenerator.Domain;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace JokeGenerator.Service
{
    public class JokeApiService : ApiService, IJokeApiService
    { 
        public JokeApiService(IConfiguration config)
        {
            _url = config.GetValue<string>("ApiUrls:Joke");
        }
        public string GetJokeText(Joke joke)
        {
            var jokeResult = "";
            if (joke.GetCategory() != null)
            {
                var categoryParameters = new Dictionary<string, string>();
                categoryParameters.Add("category", joke.GetCategory());
                jokeResult =  GetRequest(categoryParameters);
            }
            else
            {
                jokeResult = GetRequest();
            }
            
            
            var jokeText = (string) JsonConvert.DeserializeObject<dynamic>(jokeResult).value;

            if (joke.GetFirstName() != null && joke.GetLastName() != null)
            {
                jokeText = jokeText.Replace("Chuck", joke.GetFirstName());
                jokeText = jokeText.Replace("Norris", joke.GetLastName());
            }

            return jokeText;
        }
    }
}