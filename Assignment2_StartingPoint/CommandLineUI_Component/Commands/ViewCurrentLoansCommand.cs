using Controllers;
using CommandLineUI.Presenters;
using MySqlX.XDevAPI.Common;
using System.Diagnostics;

namespace CommandLineUI.Commands
{
    class ViewCurrentLoansCommand : Command
    {
        private string result;

        public ViewCurrentLoansCommand()
        {
        }

        public void Execute()
        {
            ViewCurrentLoansController controller =
                new ViewCurrentLoansController(
                        new CurrentLoansPresenter());

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

