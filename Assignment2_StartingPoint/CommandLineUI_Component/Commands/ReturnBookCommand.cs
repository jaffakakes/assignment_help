using Controllers;
using CommandLineUI.Presenters;
using MySqlX.XDevAPI.Common;

namespace CommandLineUI.Commands
{
    class ReturnBookCommand : Command
    {
        private string result;

        public ReturnBookCommand()
        {
        }

        public void Execute()
        {
            ReturnBookController controller = 
                new ReturnBookController(
                    ConsoleReader.ReadInt("\nMember ID"),
                    ConsoleReader.ReadInt("Book ID"),
                    new MessagePresenter());

            CommandLineViewData data =
                (CommandLineViewData)controller.Execute();

            result = string.Join(Environment.NewLine, data.ViewData);
        }

        public string GetResult()
        {
            return result;
        }
    }
}
