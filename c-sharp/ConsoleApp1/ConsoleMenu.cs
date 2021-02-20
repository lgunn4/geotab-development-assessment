using System;
using System.Linq;

namespace JokeGenerator
{
    public static class ConsoleMenu
    {
        private static ConsoleColor _inputTextColor = Console.ForegroundColor;
        private static ConsoleColor _promptTextColor = Console.ForegroundColor;
        private static ConsoleColor _informationTextColor = Console.ForegroundColor;
        
        public static void setInputTextColor(ConsoleColor inputTextColor)
        {
            _inputTextColor = inputTextColor;
        }

        public static void setPromptTextColor(ConsoleColor promptTextColor)
        {
            _promptTextColor = promptTextColor;
        }
        
        public static void setInformationTextColor(ConsoleColor informationTextColor)
        {
            _informationTextColor = informationTextColor;
        }
        public static void Print(string displayText, ConsoleColor foregroundColor)
        {
            var originalColor = _inputTextColor;
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(displayText);
            Console.ForegroundColor = originalColor;
        }
        
        public static void PrintInformation(string displayText)
        {
            Print(displayText, _informationTextColor);
        }
        
        public static void PrintPrompt(string displayText)
        {
            Print(displayText, _promptTextColor);
        }

        private static string PrintOption(string displayText)
        {
            PrintPrompt(displayText);
            var enteredValue = Console.ReadKey().Key.ToString();
            EmptyLine();

            return enteredValue;
        }
        
        public static string PrintOptionInput(string displayText)
        { 
            PrintPrompt(displayText);
            var enteredValue = Console.ReadLine();
            EmptyLine();

            return enteredValue;
        }

        public static string PrintOptions(string displayText, string[] options)
        {
            while (true)
            {
                var enteredInput = PrintOption(displayText);
                if (options.Contains(enteredInput))
                {
                    return enteredInput;
                }
            }
        }
        
        public static string PrintOptionsInput(string displayText, string[] options)
        {
            while (true)
            {
                var enteredInput = PrintOptionInput(displayText);
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

        public static bool PrintBoolOption(string displayText)
        {
            var option = PrintOptions(displayText, new[] {"Y", "N"});

            return option.Equals("Y");
        }

        public static int PrintIntOption(string displayText)
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

        private static int GetEnteredInt(char enteredInput)
        {
            if (char.IsDigit(enteredInput))
            {
                return int.Parse(enteredInput.ToString());
            }

            return -1;
        }

        public static void EmptyLine()
        {
            Console.WriteLine(Environment.NewLine);
        }
    }
}
