using AssignWpf.Domain;
using AssignWpf.Services;
using CommandLineUI.Commands;
using CommandLineUI.Menu;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AssignWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ICommandFactory commandFactory = new CommandFactory();
            IDtoConverter dtoConverter = new DtoConverter();
            IMenuFactory menuFactory = MenuFactory.INSTANCE;
            IMenuUI menuUI = new MenuUI(menuFactory.Create());
            MainWindow mainWindow = new MainWindow(commandFactory, dtoConverter, menuFactory, menuUI);
            mainWindow.Show();
        }
    }
}
