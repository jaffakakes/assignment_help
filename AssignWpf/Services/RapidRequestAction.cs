using CommandLineUI.Commands;
using ClientSide;
using AssignWpf.Domain;
using System.Collections.Generic;



namespace AssignWpf.Services
{
    public class RapidRequestAction : IMenuItemAction
    {

        private readonly ServerConnection serverConnection;

        public RapidRequestAction( ServerConnection serverConnection)
        {

            this.serverConnection = serverConnection;
        }

        public async void Execute(int commandId, List<string> serverResponse)
        {
            Queue<string> messageQueue = new Queue<string>();

            for (int i = 1; i <= 5; i++)
            {
                messageQueue.Enqueue($"Rapid request: {i}");
            }

            await serverConnection.ProcessAndSendMessagesAsync(messageQueue, serverConnection);
        }

       
    }
}
