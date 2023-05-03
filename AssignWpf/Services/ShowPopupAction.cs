using AssignWpf.Domain;
using ClientSide;
using System.Collections.Generic;
using System.Windows;
namespace AssignWpf.Services
{
    public class ShowPopupAction : IMenuItemAction
    {
        private MainWindow mainWindow;
        private ServerConnection serverConnection;

        public ShowPopupAction(MainWindow mainWindow, ServerConnection serverConnection)
        {
            this.mainWindow = mainWindow;
            this.serverConnection = serverConnection;
        }
    
    

    public void Execute(List<string> serverResponse)
    {
     

        PopupWindow popupWindow = new PopupWindow(mainWindow, serverConnection);
        popupWindow.ShowDialog();

        if (!string.IsNullOrEmpty(popupWindow.Response))
        {
            mainWindow.ResponseTextBlock.Text = popupWindow.Response;
        }
    }
}
}
