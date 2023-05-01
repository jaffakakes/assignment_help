using AssignWpf.Domain;
using System.Collections.Generic;
using System.Windows;
namespace AssignWpf.Services
{
    public class ShowPopupAction : IMenuItemAction
    {
        private MainWindow mainWindow;
        private int selectedCommand;
        private List<string> serverResponse;

        public ShowPopupAction(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            this.selectedCommand = selectedCommand;
        }

        public void Execute(List<string> serverResponse)
        {
            MessageBox.Show(string.Join("\n", serverResponse));

            PopupWindow popupWindow = new PopupWindow(mainWindow, serverResponse);
            popupWindow.SelectedCommand = selectedCommand;
            popupWindow.ShowDialog();

            if (!string.IsNullOrEmpty(popupWindow.Response))
            {
                mainWindow.ResponseTextBlock.Text = popupWindow.Response;
            }
        }
    }
}
