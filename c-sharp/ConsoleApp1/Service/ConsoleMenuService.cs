using System;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace JokeGenerator.Service
{

    public class ConsoleMenu : IConsoleMenu
    {
        private readonly ConsoleColor _inputTextColor;
        private readonly ConsoleColor _promptTextColor;
        private readonly ConsoleColor _informationTextColor;

        public ConsoleMenu(IConfiguration config)
        {
            var tempInputColor = config.GetValue<string>("ConsoleColor:Input");
            var tempPromptColor = config.GetValue<string>("ConsoleColor:Prompt");
            var tempInformationColor = config.GetValue<string>("ConsoleColor:Information");

            if (!Enum.TryParse(tempInputColor, out _inputTextColor))
            {
                _inputTextColor = Console.ForegroundColor;
            }
            if (!Enum.TryParse(tempPromptColor, out _promptTextColor))
            {
                _promptTextColor = Console.ForegroundColor;
            }
            if (!Enum.TryParse(tempInformationColor, out _informationTextColor))
            {
                _informationTextColor = Console.ForegroundColor;
            }
        }

        private void Print(string displayText, ConsoleColor foregroundColor)
        {
            var originalColor = _inputTextColor;
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(displayText);
            Console.ForegroundColor = originalColor;
        }
        
        public void PrintInformation(string displayText)
        {
            Print(displayText, _informationTextColor);
        }

        private void PrintPrompt(string displayText)
        {
            Print(displayText, _promptTextColor);
        }

        private string PrintPromptReturnKeyInput(string displayText)
        {
            PrintPrompt(displayText);
            var enteredValue = Console.ReadKey().Key.ToString();
            EmptyLine();

            return enteredValue;
        }
        
        public char PrintPromptReturnKeyCharInput(string displayText)
        { 
            PrintPrompt(displayText);
            var enteredValue = Console.ReadKey();
            EmptyLine();

            return enteredValue.KeyChar;
        }

        private string PrintPromptReturnLineInput(string displayText)
        { 
            PrintPrompt(displayText);
            var enteredValue = Console.ReadLine();
            EmptyLine();

            return enteredValue;
        }

        public string PrintPromptReturnOptionKeyInput(string displayText, string[] options)
        {
            while (true)
            {
                var enteredInput = PrintPromptReturnKeyInput(displayText);
                if (options.Contains(enteredInput))
                {
                    return enteredInput;
                }
            }
        }
        
        public string PrintPromptReturnOptionLineInput(string displayText, string[] options)
        {
            while (true)
            {
                var enteredInput = PrintPromptReturnLineInput(displayText);
                if (string.Empty.Equals(enteredInput))
                {
                    return enteredInput;
                }
                if (options.Contains(enteredInput))
                {
                    return enteredInput;
                }
            }
        }

        public bool PrintPromptReturnBoolOption(string displayText)
        {
            var option = PrintPromptReturnOptionKeyInput(displayText, new[] {"Y", "N"});

            return option.Equals("Y");
        }

        public int PrintPromptReturnIntInput(string displayText)
        {
            while (true)
            {
                PrintPrompt(displayText);
                var enteredInput = GetEnteredInt(Console.ReadKey().KeyChar);
                EmptyLine();
                if (enteredInput > 0)
                {
                    return enteredInput;
                }
            }
        }

        private  int GetEnteredInt(char enteredInput)
        {
            if (char.IsDigit(enteredInput))
            {
                return int.Parse(enteredInput.ToString());
            }

            return -1;
        }

        public void EmptyLine()
        {
            Console.WriteLine(Environment.NewLine);
        }

        public void PrintList(string name, string[] list)
        {
            var displayText = name + ": ";
            foreach (var item in list)
            {
                displayText = displayText + item + ", ";
            }

            displayText = displayText.Substring(0, displayText.Length - 2);
            PrintInformation(displayText);
        }
    }
}
