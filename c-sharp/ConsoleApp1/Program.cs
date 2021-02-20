using System;
using Newtonsoft.Json;

namespace JokeGenerator
{
    static class Program
    {
        private static string[] categories;

        private const string CategoryOption = "C";
        private const string RandomOption = "R";
        private const string QuitOption = "Q";
        private static readonly string[] MainMenuOptions = {CategoryOption, RandomOption, QuitOption};

        private const ConsoleColor InputTextColor = ConsoleColor.White;
        private const ConsoleColor PromptTextColor = ConsoleColor.Red;
        private const ConsoleColor InformationTextColor = ConsoleColor.Yellow;

        
        public static void Main(string[] args)
        {
            InitializeCategories();
            ConsoleMenu.setInputTextColor(InputTextColor);
            ConsoleMenu.setPromptTextColor(PromptTextColor);
            ConsoleMenu.setInformationTextColor(InformationTextColor);

            var mainMenuOption = "";
            while (!mainMenuOption.Equals(QuitOption))
            {
                switch (mainMenuOption)
                {
                    case CategoryOption:
                        var categoryList = "Categories: ";
                        foreach (var category in categories)
                        {
                            categoryList = categoryList + category + ", ";
                        }

                        categoryList = categoryList.Substring(0, categoryList.Length - 2);
                        ConsoleMenu.PrintInformation(categoryList);
                        break;
                    
                    case RandomOption:
                    {
                        Joke joke;
                        if (ConsoleMenu.PrintBoolOption("Want to use a random name? y/n"))
                        {
                            joke = new Joke();
                        }
                        else
                        {
                            var firstName = ConsoleMenu.PrintOptionInput("Enter a first Name");
                            var lastName = ConsoleMenu.PrintOptionInput("Enter a last Name");
                            
                            joke = new Joke(firstName, lastName);
                        }
                        var numberOfJokes = ConsoleMenu.PrintIntOption("How many jokes do you want? (1-9)");
                        
                        if (ConsoleMenu.PrintBoolOption("Want to specify a category? y/n"))
                        {
                            string category = ConsoleMenu.PrintOptionsInput("Enter a valid category or hit enter to skip", categories);

                            if (!string.Empty.Equals(category))
                            {
                                joke.SetCategory(category);
                            }
                        }

                        for (var i = 0; i < numberOfJokes; i++)
                        {
                            ConsoleMenu.PrintInformation(joke.GetJoke());
                        }

                        ConsoleMenu.EmptyLine();
                        break;
                    }
                }
                mainMenuOption = ConsoleMenu.PrintOptions("Press c to get categories, Press r to get random jokes, Press q to quit", MainMenuOptions);
            }
        }

        private static void InitializeCategories()
        {
            ApiService categoryApiService = new ApiService("https://api.chucknorris.io/jokes/categories");
            categories = JsonConvert.DeserializeObject<string[]>(categoryApiService.GetRequest());
            
        }
    }
}
