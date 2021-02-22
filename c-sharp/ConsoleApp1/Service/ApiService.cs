using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace JokeGenerator.Service
{
    public abstract class ApiService
    {
        protected HttpClient HttpClient;

        protected string GetRequest()
        {
            return GetRequest(null);
        }

        protected string GetRequest(Dictionary<string, string> parameters)
        {
            var urlParameters = "";
            if (parameters != null)
            {
                urlParameters = "?";
                foreach (var parametersKey in parameters.Keys)
                {
                    urlParameters = urlParameters + "&" + parametersKey + "=" + parameters[parametersKey];
                }

            }

            return Task.FromResult(HttpClient.GetStringAsync(urlParameters).Result).Result;
        }
    }
}