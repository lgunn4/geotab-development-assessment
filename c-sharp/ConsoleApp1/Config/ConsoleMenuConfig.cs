using System;
using JokeGenerator.Config.Interface;
using Microsoft.Extensions.Configuration;

namespace JokeGenerator.Config
{
    public class ConsoleMenuConfig : IConsoleMenuConfig
    {
        private const ConsoleColor DefaultColor = ConsoleColor.White;
        public ConsoleColor InputTextColor { get; }
        public ConsoleColor PromptTextColor { get; }
        public ConsoleColor InformationTextColor { get; }

        public ConsoleMenuConfig(IConfiguration config)
        {
            InputTextColor = DefaultColor;
            PromptTextColor = DefaultColor;
            InformationTextColor = DefaultColor;
            
            var tempInputColor = config.GetValue<string>("ConsoleColor:Input");
            var tempPromptColor = config.GetValue<string>("ConsoleColor:Prompt");
            var tempInformationColor = config.GetValue<string>("ConsoleColor:Information");

            if (Enum.TryParse(tempInputColor, out ConsoleColor _))
            {
                InputTextColor = (ConsoleColor) Enum.Parse(typeof(ConsoleColor), tempInputColor);
            }

            if (Enum.TryParse(tempPromptColor, out ConsoleColor _))
            {
                PromptTextColor = (ConsoleColor) Enum.Parse(typeof(ConsoleColor), tempPromptColor);
            }

            if (Enum.TryParse(tempInformationColor, out ConsoleColor _))
            {
                InformationTextColor = (ConsoleColor) Enum.Parse(typeof(ConsoleColor), tempInformationColor);
            }
        }

        public ConsoleColor GetDefaultColor()
        {
            return DefaultColor;
        }
    }
}