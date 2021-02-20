using System;
using Newtonsoft.Json;

namespace JokeGenerator
{
    internal static class Program
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
            
            // Initializing category list and setting ConsoleColor for ConsoleMenu
            CategoryService.InitializeCategories();
            ConsoleMenu.SetInputTextColor(InputTextColor);
            ConsoleMenu.SetPromptTextColor(PromptTextColor);
            ConsoleMenu.SetInformationTextColor(InformationTextColor);

            var mainMenuOption = "";
            
            // Loops until User Quits
            while (!mainMenuOption.Equals(QuitOption))
            {
                switch (mainMenuOption)
                {
                    
                    // User chooses to see list of all categories
                    case CategoryOption:
                        var categoryList = "Categories: ";
                        foreach (var category in categories)
                        {
                            categoryList = categoryList + category + ", ";
                        }

                        categoryList = categoryList.Substring(0, categoryList.Length - 2);
                        ConsoleMenu.PrintInformation(categoryList);
                        break;
                    
                    // User chooses to get Random Jokes
                    case RandomOption:
                    {
                        
                        // Joke constructor is chosen depending on User Input
                        Joke joke;
                        if (ConsoleMenu.PrintPromptReturnBoolOption("Want to use a random name? y/n"))
                        {
                            var randomName = RandomNameService.GetRandomName();
                            joke = new Joke(randomName.Item1, randomName.Item2);
                        }
                        else
                        {
                            var firstName = ConsoleMenu.PrintPromptReturnLineInput("Enter a first Name");
                            var lastName = ConsoleMenu.PrintPromptReturnLineInput("Enter a last Name");
                            
                            joke = new Joke(firstName, lastName);
                        }
                        
                        // User is prompted for number of jokes
                        var numberOfJokes = ConsoleMenu.PrintPromptReturnIntInput("How many jokes do you want? (1-9)");
                        
                        // User chooses to enter a category or not
                        if (ConsoleMenu.PrintPromptReturnBoolOption("Want to specify a category? y/n"))
                        {
                            string category = ConsoleMenu.PrintOptionsInput("Enter a valid category or hit enter to skip", categories);

                            if (!string.Empty.Equals(category))
                            {
                                joke.SetCategory(category);
                            }
                        }

                        // Jokes are all displayed
                        for (var i = 0; i < numberOfJokes; i++)
                        {
                            ConsoleMenu.PrintInformation(JokeService.GetJokeText(joke));
                        }

                        ConsoleMenu.EmptyLine();
                        break;
                    }
                }
                
                // User is prompted for Menu Choice
                mainMenuOption = ConsoleMenu.PrintPromptReturnOptionKeyInput("Press c to get categories, Press r to get random jokes, Press q to quit", MainMenuOptions);
            }
        }

        private static void InitializeCategories()
        {
            ApiService categoryApiService = new ApiService("https://api.chucknorris.io/jokes/categories");
            categories = JsonConvert.DeserializeObject<string[]>(categoryApiService.GetRequest());
            
        }
    }
}
