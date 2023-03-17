using Controllers;
using CommandLineUI.Presenters;
using MySqlX.XDevAPI.Common;

namespace CommandLineUI.Commands
{
    class RenewLoanCommand : Command
    {
        private int _memberId;
        private int _bookId;
        private string result;

        public RenewLoanCommand(int memberId, int bookId)
        {
            _memberId = memberId;
            _bookId = bookId;
        }

        public void Execute()
        {
            RenewLoanController controller = 
                new RenewLoanController(
                    _memberId,
                    _bookId,
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
