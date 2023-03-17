using Controllers;
using CommandLineUI.Presenters;
using MySqlX.XDevAPI.Common;

namespace CommandLineUI.Commands
{
    class RenewLoanCommand : Command
    {
        private string result;

        public RenewLoanCommand()
        {
        }

        public void Execute()
        {
            RenewLoanController controller = 
                new RenewLoanController(
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
