using Controllers;
using CommandLineUI.Presenters;
using MySqlX.XDevAPI.Common;

namespace CommandLineUI.Commands
{
    class InitialiseDatabaseCommand : Command
    {
        private string result;

        public InitialiseDatabaseCommand()
        {
        }

        public void Execute()
        {
            InitialiseDatabaseController controller =
                new InitialiseDatabaseController(
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
