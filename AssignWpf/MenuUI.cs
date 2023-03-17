
using CommandLineUI.Menu;
using System.Collections.Generic;
using System.Windows.Controls;

namespace AssignWpf
{
    public class MenuUI
    {
        private Menus _menu;

        public MenuUI(Menus menu)
        {
            _menu = menu;
        }

        public void DisplayInListBox(ListBox listBox)
        {
            listBox.Items.Clear();
            AddMenuElementToListBox(_menu, listBox);
        }

        private void AddMenuElementToListBox(MenuElement menuElement, ListBox listBox)
        {
            if (menuElement is Menus menu)
            {
                foreach (MenuElement child in menu.Children)
                {
                    AddMenuElementToListBox(child, listBox);
                }
            }
            else if (menuElement is MenuItems menuItem)
            {
                listBox.Items.Add(menuItem);
            }
        }
    }
}

