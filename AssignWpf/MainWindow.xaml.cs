using System.Windows;
using System.Windows.Controls;
using CommandLineUI.Menu;
using CommandLineUI;
using CommandLineUI.Commands;
namespace AssignWpf
{
    public partial class MainWindow : Window
    {
        private MenuUI menuUI;

        public MainWindow()
        {
            InitializeComponent();

            MenuFactory menuFactory = MenuFactory.INSTANCE;
            Menus menu = (Menus)menuFactory.Create();
            menuUI = new MenuUI(menu);

            // Populate the ListBox with menu items
            menuUI.DisplayInListBox(menuListBox);
        }

        private void MenuListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (menuListBox.SelectedItem != null)
            {
                MenuItems menuItem = (MenuItems)menuListBox.SelectedItem;

                CommandFactory commandFactory = new CommandFactory();

                if (menuItem.Id == RequestUseCase.VIEW_ALL_BOOKS ||
                    menuItem.Id == RequestUseCase.VIEW_ALL_MEMBERS ||
                    menuItem.Id == RequestUseCase.VIEW_CURRENT_LOANS)
                {
                    Command command = commandFactory.CreateCommand(menuItem.Id);
                    command.Execute();
                    string result = command.GetResult();
                    responseTextBlock.Text = result;
                }
                else if(menuItem.Id == RequestUseCase.BORROW_BOOK || menuItem.Id == RequestUseCase.RETURN_BOOK || menuItem.Id == RequestUseCase.RENEW_LOAN)
                {
                    PopupWindow popupWindow = new PopupWindow(this);
                    popupWindow.SelectedCommand = menuItem.Id; // Set the selected command
                    popupWindow.ShowDialog(); // Show the popup window as a modal dialog

                    if (!string.IsNullOrEmpty(popupWindow.Response))
                    {
                        responseTextBlock.Text = popupWindow.Response;
                    }
                }
                else if(menuItem.Id == RequestUseCase.EXIT)
                {
                    this.Close();
                }

                menuListBox.SelectedItem = null; // Deselect the item in the ListBox
            }
        }
    }
    }




