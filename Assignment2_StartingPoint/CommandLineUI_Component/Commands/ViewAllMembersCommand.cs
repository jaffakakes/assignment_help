using Controllers;
using CommandLineUI.Presenters;
using MySqlX.XDevAPI.Common;

namespace CommandLineUI.Commands
{
    class ViewAllMembersCommand : Command
    {
        private string result;

        public ViewAllMembersCommand()
        {
        }

        public void Execute()
        {
            ViewAllMembersController controller =
                new ViewAllMembersController(
                        new AllMembersPresenter());

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
