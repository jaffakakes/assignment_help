using System.Windows;
using System.Windows.Controls;
using CommandLineUI.Menu;
using CommandLineUI;
using CommandLineUI.Commands;
using AssignWpf.Services;
using AssignWpf.Domain;
using System.Collections.Generic;

namespace AssignWpf
{
    public partial class MainWindow : Window
    {
        private readonly ICommandFactory commandFactory;
        private readonly IDtoConverter dtoConverter;
        private readonly IMenuUI menuUI;
        private readonly MenuSelectionHandler menuSelectionHandler;
        private readonly Dictionary<int, IMenuItemAction> menuItemActions;
        public TextBlock ResponseTextBlock => responseTextBlock;



        public MainWindow(ICommandFactory commandFactory, IDtoConverter dtoConverter, IMenuFactory menuFactory, IMenuUI menuUI)
        {
            InitializeComponent();

            this.commandFactory = commandFactory;
            this.dtoConverter = dtoConverter;
            this.menuUI = menuUI;
            menuItemActions = new Dictionary<int, IMenuItemAction>
        {
            { RequestUseCase.VIEW_CURRENT_LOANS, new ViewCurrentLoansAction(commandFactory, dtoConverter, responseDataGrid) },
            { RequestUseCase.VIEW_ALL_MEMBERS, new ViewAllMembersAction(commandFactory, dtoConverter, responseDataGrid) },
            { RequestUseCase.VIEW_ALL_BOOKS, new ViewAllBooksAction(commandFactory, dtoConverter, responseDataGrid) },
            { RequestUseCase.BORROW_BOOK, new ShowPopupAction(this, RequestUseCase.BORROW_BOOK) },
            { RequestUseCase.RETURN_BOOK, new ShowPopupAction(this, RequestUseCase.RETURN_BOOK) },
            { RequestUseCase.RENEW_LOAN, new ShowPopupAction(this, RequestUseCase.RENEW_LOAN) },
            { RequestUseCase.EXIT, new ExitAction(this) }
         };
            menuSelectionHandler = new MenuSelectionHandler(commandFactory, dtoConverter, menuItemActions, this);

            Menus menu = (Menus)menuFactory.Create();
            menuUI.DisplayInListBox(menuListBox);
        }

        private void MenuListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            menuSelectionHandler.MenuListBox_SelectionChanged(sender, e);
        }

    }
    }




