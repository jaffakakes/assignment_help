using AssignWpf.Domain;
using CommandLineUI.Commands;
using CommandLineUI.Menu;
using System.Collections.Generic;
using System.Windows.Controls;

namespace AssignWpf.Services
{
    public class MenuSelectionHandler
    {
        private ICommandFactory commandFactory;
        private IDtoConverter dtoConverter;
        private Dictionary<int, IMenuItemAction> menuItemActions;
        private MainWindow mainWindow;

        public MenuSelectionHandler(ICommandFactory commandFactory, IDtoConverter dtoConverter, Dictionary<int, IMenuItemAction> menuItemActions, MainWindow mainWindow)
        {
            this.commandFactory = commandFactory;
            this.dtoConverter = dtoConverter;
            this.menuItemActions = menuItemActions;
            this.mainWindow = mainWindow;
        }

        public void MenuListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox menuListBox = sender as ListBox;

            if (menuListBox.SelectedItem != null)
            {
                MenuItems menuItem = (MenuItems)menuListBox.SelectedItem;

                if (menuItemActions.ContainsKey(menuItem.Id))
                {
                    menuItemActions[menuItem.Id].Execute();
                }

                menuListBox.SelectedItem = null; 
            }
        }
    }

}
