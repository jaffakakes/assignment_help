using CommandLineUI.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineUI.Menu
{
    public interface IMenuFactory
    {
        Menus Create();
    }
}