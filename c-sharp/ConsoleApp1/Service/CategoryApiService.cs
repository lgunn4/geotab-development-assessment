using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace JokeGenerator.Service
{
    public class CategoryApiService : ICategoryApiService
    {
        private readonly ApiService _categoryApiService;

        public CategoryApiService(IConfiguration config)
        {
            _categoryApiService = new ApiService(config.GetValue<string>("ApiUrls:Category"));
        }


        public string[] GetCategories()
        {
            return JsonConvert.DeserializeObject<string[]>(_categoryApiService.GetRequest());
        }
    }
}