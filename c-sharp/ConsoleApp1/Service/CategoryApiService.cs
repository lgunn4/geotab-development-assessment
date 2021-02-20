using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace JokeGenerator.Service
{
    public class CategoryApiService : ApiService, ICategoryApiService
    {
        public CategoryApiService(IConfiguration config)
        {
            _url = config.GetValue<string>("ApiUrls:Category");
        }


        public string[] GetCategories()
        {
            return JsonConvert.DeserializeObject<string[]>(GetRequest());
        }
    }
}