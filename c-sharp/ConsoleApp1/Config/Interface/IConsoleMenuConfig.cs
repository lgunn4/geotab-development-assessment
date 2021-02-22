using System;

namespace JokeGenerator.Config.Interface
{
    public interface IConsoleMenuConfig
    {
        ConsoleColor InputTextColor { get; }
        ConsoleColor PromptTextColor { get; }
        ConsoleColor InformationTextColor { get; }
    }
}