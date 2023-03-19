using DTOs;
using UseCase;

namespace CommandLineUI.Presenters
{
    class AllBooksPresenter : AbstractPresenter
    {

        public override IViewData ViewData
        {
            get
            {
                List<BookDTO> books = ((BookDTO_List)DataToPresent).List;
                List<string> lines = new List<string>(books.Count + 2);
             

                books.ForEach(b => lines.Add(DisplayBook(b)));

                return new CommandLineViewData(lines);
            }
        }

        private string DisplayBook(BookDTO b)
        {
            return string.Join(",",
      b.Id.ToString().PadRight(4),
      b.Title.PadRight(20),
      b.Author.PadRight(20),
      b.ISBN.PadRight(15),
      b.State);
        }
    }
}
