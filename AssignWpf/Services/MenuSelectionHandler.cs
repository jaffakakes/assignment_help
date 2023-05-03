using AssignWpf.Domain;
using CommandLineUI.Commands;
using CommandLineUI.Menu;
using System.Collections.Generic;
using System.Windows.Controls;
using ClientSide;

namespace AssignWpf.Services
{
    public class MenuSelectionHandler
    {
        private ICommandFactory commandFactory;
        private IDtoConverter dtoConverter;
        private Dictionary<int, IMenuItemAction> menuItemActions;
        private MainWindow mainWindow;
        private ServerConnection serverConnection;

        public MenuSelectionHandler(ICommandFactory commandFactory, IDtoConverter dtoConverter, Dictionary<int, IMenuItemAction> menuItemActions, MainWindow mainWindow, ServerConnection serverConnection)
        {
            this.commandFactory = commandFactory;
            this.dtoConverter = dtoConverter;
            this.menuItemActions = menuItemActions;
            this.mainWindow = mainWindow;
            this.serverConnection = serverConnection;
        }

        public void MenuListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox menuListBox = sender as ListBox;

            if (menuListBox.SelectedItem != null)
            {
                MenuItems menuItem = (MenuItems)menuListBox.SelectedItem;

                if (menuItemActions.ContainsKey(menuItem.Id))
                {
                    // Send the action key to the server and get the server's response
                    List<string> serverResponse = serverConnection.SendAction(menuItem.Id);

                    // Pass the server's response to the Execute() method of the corresponding menu item action
                    menuItemActions[menuItem.Id].Execute(menuItem.Id, serverResponse);
                }

                menuListBox.SelectedItem = null;
            }
        }
    }
}
