using AssignWpf.Domain;
using System.Collections.Generic;

namespace AssignWpf.Services
{
    public class ShowPopupAction : IMenuItemAction
    {
        private MainWindow mainWindow;
        private int selectedCommand;

        public ShowPopupAction(MainWindow mainWindow, int selectedCommand)
        {
            this.mainWindow = mainWindow;
            this.selectedCommand = selectedCommand;
        }

        public void Execute(List<string> serverResponse)
        {
    
            PopupWindow popupWindow = new PopupWindow(mainWindow);
            popupWindow.SelectedCommand = selectedCommand;
            popupWindow.ShowDialog();

            if (!string.IsNullOrEmpty(popupWindow.Response))
            {
                mainWindow.ResponseTextBlock.Text = popupWindow.Response;
            }
        }
    }
}
