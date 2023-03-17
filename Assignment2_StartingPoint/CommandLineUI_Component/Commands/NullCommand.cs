using System.Collections.Generic;

namespace CommandLineUI.Commands
{
    class NullCommand : Command
    {
        private string result;

        public NullCommand()
        {
        }

        public void Execute()
        {
            List<string> messages = new List<string>() { "Menu choice not recognised" };
            ConsoleWriter.WriteStrings(messages);

            // Store the result as a single string
            result = string.Join(Environment.NewLine, messages);
        }

        public string GetResult()
        {
            return result;
        }
    }
}

