using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CommandLineUI.Menu;
using System.Windows;

namespace AssignmentWpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Menu mainMenu = new Menu("Main Menu");
            Menu subMenu1 = new Menu("Sub Menu 1");
            mainMenu.Add(subMenu1);
            subMenu1.Add(new MenuItem(1, "Sub Menu 1 - Item 1"));
            subMenu1.Add(new MenuItem(2, "Sub Menu 1 - Item 2"));

            mainMenu.Add(new MenuItem(3, "Main Menu - Item 1"));
            mainMenu.Add(new MenuItem(4, "Main Menu - Item 2"));

            mainMenu.PrintTo(MenuListBox);
        }
    }
}

