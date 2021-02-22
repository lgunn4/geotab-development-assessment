namespace JokeGenerator.Config.Interface
{
    public interface IMenuConfig
    { 
        string MainMenuPrompt { get; }
        string CategoryOption { get; }
        string RandomJokeOption { get; }
        string QuitOption { get; }
        string[] MainMenuOptions { get; }
        string InstructionsPrompt { get; }
        char InstructionsChar { get; }
        string RandomNamePrompt { get; }
        string NumberOfJokesPrompt { get; }
        string SpecifyCategoryPrompt { get; }
        string CategoryInputPrompt { get; }
        
    }
}