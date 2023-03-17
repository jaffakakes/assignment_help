
using System.Collections.Generic;

namespace CommandLineUI.Menu
{
    // This class implements the Composite design pattern
    public class Menus : MenuElement
    {
        private List<MenuElement> children;
        public IReadOnlyList<MenuElement> Children => children;

        public Menus(string text) : base(-1, text)                                  
        {
            children = new List<MenuElement>();
        }

        public void Add(MenuElement menuElement)
        {
            children.Add(menuElement);
        }

        public override void Print(string indent)
        {
            // Provide an empty implementation for the Print method
            // You can implement the desired functionality here as needed
        }                                                                                                    
    }
}