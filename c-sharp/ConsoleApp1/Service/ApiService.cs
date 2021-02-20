using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace JokeGenerator.Service
{
    public class ApiService
    {
        private readonly string _url;

        public ApiService(string url)
        {
            _url = url;
        }

        public string GetRequest()
        {
            return GetRequest(null);
        }
        
        public string GetRequest(Dictionary<string, string> parameters)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_url);
            
            var urlParameters = "";
            if (parameters != null)
            {
                urlParameters = "?";
                foreach (var parametersKey in parameters.Keys)
                {
                    urlParameters = urlParameters + "&" + parametersKey + "=" + parameters[parametersKey];
                }

            }

            return Task.FromResult(client.GetStringAsync(urlParameters).Result).Result;
        }
    }
}