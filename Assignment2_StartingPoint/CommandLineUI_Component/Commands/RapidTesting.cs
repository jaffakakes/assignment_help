using System.Collections.Generic;

namespace CommandLineUI.Commands
{
    class RapidTesting : Command
    {
        private string result;

        public RapidTesting()
        {
        }

        public void Execute()
        {
            List<string> messages = new List<string>() { "Rapid Testing" };
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
