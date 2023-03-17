using System;

namespace CommandLineUI.Menu
{
    public class MenuItems : MenuElement
    {
        public int Id { get; private set; }

        public MenuItems(int id, string text) : base(id, text)
        {
            Id = id;
        }

        public override void Print(string indent)
        {
            Console.WriteLine("{0}{1}. {2}", indent, Id, Text);
        }
    }
}