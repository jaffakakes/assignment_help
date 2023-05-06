using CommandLineUI.Commands;
using ClientSide;
using AssignWpf.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssignWpf.Services
{
    public class RapidRequestAction : IMenuItemAction
    {
        private readonly ICommandFactory commandFactory;
        private readonly ServerConnection serverConnection;


        public RapidRequestAction(ICommandFactory commandFactory, ServerConnection serverConnection)
        {
            this.commandFactory = commandFactory;
            this.serverConnection = serverConnection;
        }

        public async void Execute(int commandId,List<string> serverResponse)
        {
            RapidRequestCommand command = commandFactory.CreateRapidRequestCommand();
            for (int i = 1; i <= 300; i++)
            {
                serverConnection.SendMessage($"Rapid request: {i}");
                await Task.Delay(50); // Add a delay to control the rate of requests sent
            }
        }
    }
}
