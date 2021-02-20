using System;
using System.Linq;

namespace JokeGenerator
{
    public static class ConsoleMenu
    {
        public static string PrintOption(string value)
        { 
            Console.WriteLine(value);
            var enteredValue =  Console.ReadKey().Key.ToString();
            Console.WriteLine(Environment.NewLine);

            return enteredValue;
        }

        public static string PrintOptions(string value, string[] options)
        {
            while (true)
            {
                var enteredInput = PrintOption(value);
                if (options.Contains(enteredInput))
                {
                    return enteredInput;
                }
            }
        }

        public static bool PrintBoolOption(string value)
        {
            var option = PrintOptions(value, new[] {"Y", "N"});

            return option.Equals("Y");
        }

        public static int PrintIntOption(string value)
        {
            while (true)
            {
                var enteredInput = GetEnteredInt(PrintOption(value));
                if (enteredInput > 0)
                {
                    return enteredInput;
                }
            }
        }

        private static int GetEnteredInt(string enteredInput)
        {
            if (char.IsDigit(char.Parse(enteredInput)))
            {
                return int.Parse(enteredInput);
            }

            return -1;
        }
    }
}
