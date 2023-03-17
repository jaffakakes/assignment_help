using Controllers;
using CommandLineUI.Presenters;


namespace CommandLineUI.Commands
{
    public class BorrowBookCommand : Command
    {
        private int _memberId;
        private int _bookId;
        private string _result;

        public BorrowBookCommand(int memberId, int bookId)
        {
            _memberId = memberId;
            _bookId = bookId;
        }

        public void Execute()
        {
            BorrowBookController controller =
                new BorrowBookController(_memberId, _bookId, new MessagePresenter());

            CommandLineViewData data =
                (CommandLineViewData)controller.Execute();

            // Assuming data.ViewData is a List<string>
            _result = string.Join(Environment.NewLine, data.ViewData);
        }

        public string GetResult()
        {
            return _result;
        }
    }

}
