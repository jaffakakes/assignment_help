using System.Windows;
using System.Windows.Controls;
using CommandLineUI.Menu;
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

                if (menuItem.Id == RequestUseCase.EXIT)
                {
                    this.Close(); // Close the main window
                }
                else
                {
                    PopupWindow popupWindow = new PopupWindow(this);
                    popupWindow.SelectedCommand = menuItem.Id; // Set the selected command
                    popupWindow.ShowDialog(); // Show the popup window as a modal dialog

                    if (!string.IsNullOrEmpty(popupWindow.Response))
                    {
                        responseTextBlock.Text = popupWindow.Response;
                    }
                }

                menuListBox.SelectedItem = null; // Deselect the item in the ListBox
            }
        }
    }
    }




