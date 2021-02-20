using System;
using System.Linq;

namespace JokeGenerator
{
    public static class ConsoleMenu
    {
        public static string PrintOption(string displayText)
        { 
            Console.WriteLine(displayText);
            var enteredValue =  Console.ReadKey().Key.ToString();
            Console.WriteLine(Environment.NewLine);

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

        public static bool PrintBoolOption(string displayText)
        {
            var option = PrintOptions(displayText, new[] {"Y", "N"});

            return option.Equals("Y");
        }

        public static int PrintIntOption(string displayText)
        {
            while (true)
            {
                Console.WriteLine(displayText);
                var enteredInput = GetEnteredInt(Console.ReadKey().KeyChar);
                Console.WriteLine(Environment.NewLine);
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
    }
}
