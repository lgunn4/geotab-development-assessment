using Microsoft.Extensions.Configuration;

namespace JokeGenerator.Config
{
    public class MenuConfig : IMenuConfig
    {
        public string MainMenuPrompt { get; }
        public string CategoryOption { get; }
        public string RandomJokeOption { get; }
        public string QuitOption { get; }
        public string[] MainMenuOptions { get; }
        public string InstructionsPrompt { get; }
        public char InstructionsChar { get; }
        public string RandomNamePrompt { get; }
        public string NumberOfJokesPrompt { get; }
        public string SpecifyCategoryPrompt { get; }
        public string CategoryInputPrompt { get; }

        public MenuConfig(IConfiguration config)
        {
            MainMenuPrompt = config.GetValue<string>("Prompts:MainMenu");
            CategoryOption = config.GetValue<string>("Inputs:Category");
            RandomJokeOption = config.GetValue<string>("Inputs:RandomJoke");
            QuitOption = config.GetValue<string>("Inputs:Quit");
            MainMenuOptions =  new string[]{CategoryOption, RandomJokeOption, QuitOption};

            InstructionsPrompt = config.GetValue<string>("Prompts:Instructions");
            InstructionsChar = config.GetValue<string>("Inputs:Instructions").ToCharArray()[0];
            RandomNamePrompt = config.GetValue<string>("Prompts:RandomName");
            NumberOfJokesPrompt = config.GetValue<string>("Prompts:NumberOfJokes");
            SpecifyCategoryPrompt = config.GetValue<string>("Prompts:SpecifyCategory");
            CategoryInputPrompt = config.GetValue<string>("Prompts:CategoryInput");
        }
    }
    
}