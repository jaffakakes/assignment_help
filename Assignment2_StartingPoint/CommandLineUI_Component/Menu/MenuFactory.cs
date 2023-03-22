namespace CommandLineUI.Menu
{
    public class MenuFactory : IMenuFactory
    {
        public static MenuFactory INSTANCE { get; } = new MenuFactory();

        private Menus menu;

        private MenuFactory()
        {
            menu = CreateMenu();
        }

        public Menus Create()
        {
            return menu;
        }

        private Menus CreateMenu()
        {
            Menus menu = new Menus("Library menu");

            menu.Add(CreateLoanMenu());
            menu.Add(CreateViewMenu());
            menu.Add(CreateAppMenu());

            return menu;
        }

        private Menus CreateAppMenu()
        {
            Menus menu = new Menus("App menu");
            menu.Add(new MenuItems(RequestUseCase.EXIT, "Exit"));
            return menu;
        }

        private Menus CreateLoanMenu()
        {
            Menus menu = new Menus("Loan menu");
            menu.Add(new MenuItems(RequestUseCase.BORROW_BOOK, "Borrow book"));
            menu.Add(new MenuItems(RequestUseCase.RETURN_BOOK, "Return book"));
            menu.Add(new MenuItems(RequestUseCase.RENEW_LOAN, "Renew loan"));
            return menu;
        }

        private Menus CreateViewMenu()
        {
            Menus menu = new Menus("View menu");
            menu.Add(new MenuItems(RequestUseCase.VIEW_ALL_BOOKS, "View all books"));
            menu.Add(new MenuItems(RequestUseCase.VIEW_ALL_MEMBERS, "View all members"));
            menu.Add(new MenuItems(RequestUseCase.VIEW_CURRENT_LOANS, "View current loans"));
            return menu;
        }
    }
}