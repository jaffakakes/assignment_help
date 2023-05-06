using CommandLineUI.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineUI.Commands
{
    public interface ICommandFactory
    {
        Command CreateCommand(int menuChoice, int number1 = 0, int number2 = 0);
    
    }
}
