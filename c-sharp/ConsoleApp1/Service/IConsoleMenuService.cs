namespace JokeGenerator.Service
{
    public interface IConsoleMenu
    {
        void PrintInformation(string displayText);

        char PrintPromptReturnKeyCharInput(string displayText);

        string PrintPromptReturnOptionKeyInput(string displayText, string[] options);

        string PrintPromptReturnOptionLineInput(string displayText, string[] options);


        bool PrintPromptReturnBoolOption(string displayText);

        int PrintPromptReturnIntInput(string displayText);

        void EmptyLine();

        void PrintList(string name, string[] list);
    }
}