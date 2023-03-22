using AssignWpf.Domain;


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

        public void Execute()
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
