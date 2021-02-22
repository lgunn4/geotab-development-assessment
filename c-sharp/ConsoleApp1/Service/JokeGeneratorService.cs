using JokeGenerator.Config.Interface;
using JokeGenerator.Domain;
using JokeGenerator.Service.Interface;

namespace JokeGenerator.Service
{
    public class JokeGeneratorService : IJokeGeneratorService
    {
        private readonly IJokeApiService _jokeApiService;
        private readonly ICategoryApiService _categoryApiService;
        private readonly IRandomNameApiService _randomNameApiService;
        private readonly IConsoleMenu _consoleMenu;
        private readonly IMenuConfig _menuConfig;

        public JokeGeneratorService(
            ICategoryApiService categoryApiService, 
            IJokeApiService jokeApiService, 
            IRandomNameApiService randomNameApiService,
            IConsoleMenu consoleMenu,
            IMenuConfig menuConfig)
        {
            _menuConfig = menuConfig;
            _jokeApiService = jokeApiService;
            _categoryApiService = categoryApiService;
            _randomNameApiService = randomNameApiService;
            _consoleMenu = consoleMenu;
        }
        
        public void Run()
        {
            if (!_consoleMenu.PrintPromptReturnKeyCharInput(_menuConfig.InstructionsPrompt).Equals(_menuConfig.InstructionsChar)) return;

            var mainMenuOption = "";
            while (!mainMenuOption.Equals(_menuConfig.QuitOption))
            {
                if (mainMenuOption.Equals(_menuConfig.CategoryOption))
                {
                    _consoleMenu.PrintList("Categories: ", _categoryApiService.GetCategories());
                }

                else if (mainMenuOption.Equals(_menuConfig.RandomJokeOption)) 
                {
                    
                    Joke joke;
                    if (_consoleMenu.PrintPromptReturnBoolOption(_menuConfig.RandomNamePrompt))
                    {
                        var randomName = _randomNameApiService.GetRandomName();
                        joke = new Joke(randomName.Item1, randomName.Item2);
                    }
                    else
                    {
                        joke = new Joke();
                    }
                        
                    var numberOfJokes = _consoleMenu.PrintPromptReturnIntInput(_menuConfig.NumberOfJokesPrompt);
                        
                    if (_consoleMenu.PrintPromptReturnBoolOption(_menuConfig.SpecifyCategoryPrompt))
                    {
                        _consoleMenu.PrintList("Categories: ", _categoryApiService.GetCategories());
                        var category = _consoleMenu.PrintPromptReturnOptionLineInput(_menuConfig.CategoryInputPrompt, _categoryApiService.GetCategories());

                        if (!string.Empty.Equals(category))
                        {
                            joke.Category = category;
                        }
                    }
                    
                    _consoleMenu.PrintInformation("Jokes: ");
                    for (var i = 0; i < numberOfJokes; i++)
                    {
                        _consoleMenu.PrintInformation(_jokeApiService.GetJokeText(joke));
                    }
                    _consoleMenu.EmptyLine();

                }

                mainMenuOption = _consoleMenu.PrintPromptReturnOptionKeyInput(_menuConfig.MainMenuPrompt, _menuConfig.MainMenuOptions);
            }
        }
        
    }
}