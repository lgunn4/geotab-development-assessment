using System;
using System.Collections;
using System.Linq;
using System.Xml;

namespace JokeGenerator
{
    class Program
    {
        static string[] results = new string[50];
        static Tuple<string, string> names;

        private const string CategoryOption = "C";
        private const string RandomOption = "R";
        private const string QuitOption = "Q";

        private static readonly string[] MainMenuOptions = new[] {CategoryOption, RandomOption, QuitOption};

        //TODO: Initialize this arrayList when the program starts to all categories in the API
        private static ArrayList categories = new ArrayList();

        public static void Main(string[] args) // needed to be public 
        {
            if (ConsoleMenu.PrintOption("Press ? to get instructions.").Equals("?")) return;  // bug here needed .equals

            var mainMenuOption = "";
            while (!mainMenuOption.Equals(QuitOption)) //infinite loop in original code assume needs quit command.
            {
                mainMenuOption = ConsoleMenu.PrintOptions("Press c to get categories, Press r to get random jokes, Press q to quit", MainMenuOptions);

                switch (mainMenuOption)
                {
                    case CategoryOption:
                        Console.WriteLine(categories.ToArray().ToString());
                        break;
                    case RandomOption:
                    {
                        if (ConsoleMenu.PrintBoolOption("Want to use a random name? y/n"))
                            GetNames();

                        var category = "";
                        var numberOfJokes = ConsoleMenu.PrintIntOption("How many jokes do you want? (1-9)");
                        if (ConsoleMenu.PrintBoolOption("Want to specify a category? y/n"))
                        {
                            category = ConsoleMenu.PrintOptions("Enter a category", categories.ToArray() as string[]);
                        }

                        GetRandomJokes(category, numberOfJokes);
                        PrintResults();

                        break;
                    }
                }
            }
        }

        private static void PrintResults()
        {
            Console.WriteLine("[" + string.Join(",", results) + "]");
        }

       

        private static void GetRandomJokes(string category, int number)
        {
            new JsonFeed("https://api.chucknorris.io", number);
            results = JsonFeed.GetRandomJokes(names?.Item1, names?.Item2, category);
        }

        private static void getCategories()
        {
            new JsonFeed("https://api.chucknorris.io", 0);
            results = JsonFeed.GetCategories();
        }

        private static void GetNames()
        {
            new JsonFeed("https://www.names.privserv.com/api/", 0);
            dynamic result = JsonFeed.Getnames();
            names = Tuple.Create(result.name.ToString(), result.surname.ToString());
        }
    }
}
