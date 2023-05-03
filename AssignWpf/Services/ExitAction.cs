using AssignWpf.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignWpf.Services
{
    public class ExitAction : IMenuItemAction
    {
        private MainWindow mainWindow;

        public ExitAction(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public void Execute(int commandId, List<string> serverResponse)
        {
            mainWindow.Close();
        }
    }
}
