using Controllers;
using CommandLineUI.Presenters;
using MySqlX.XDevAPI.Common;

namespace CommandLineUI.Commands
{
    class ViewAllBooksCommand : Command
    {
        private string result;

        public ViewAllBooksCommand()
        {
        }

        public void Execute()
        {
            ViewAllBooksController controller =
                new ViewAllBooksController(
                        new AllBooksPresenter());

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
