using Newtonsoft.Json;

namespace JokeGenerator
{
    public static class CategoryService
    {
        private static string[] _categories;
        private static readonly ApiService CategoryApiService = new ApiService("https://api.chucknorris.io/jokes/categories");


        public static void InitializeCategories()
        {
            _categories = JsonConvert.DeserializeObject<string[]>(CategoryApiService.GetRequest());
            
        }

        public static string[] GetCategories()
        {
            return _categories;
        }

        public static void DisplayCategories()
        {
            var categoryList = "Categories: ";
            foreach (var category in _categories)
            {
                categoryList = categoryList + category + ", ";
            }

            categoryList = categoryList.Substring(0, categoryList.Length - 2);
            ConsoleMenu.PrintInformation(categoryList);
        }
    }
}