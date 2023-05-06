using CommandLineUI.Commands;
using ClientSide;
using AssignWpf.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Diagnostics;

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

        public async void Execute(int commandId, List<string> serverResponse)
        {
            // Create a queue to store the messages
            Queue<string> messageQueue = new Queue<string>();

            // Enqueue the messages
            for (int i = 1; i <= 5; i++)
            {
                messageQueue.Enqueue($"Rapid request: {i}");
            }

            // Call the ProcessAndSendMessagesAsync method with the messageQueue and serverConnection as arguments
            await ProcessAndSendMessagesAsync(messageQueue, serverConnection);
        }

        private async Task ProcessAndSendMessagesAsync(Queue<string> messageQueue, ServerConnection serverConnection)
        {
            while (messageQueue.Count > 0)
            {
                string message = messageQueue.Dequeue();
            
                serverConnection.SendMessage(message);
                await Task.Delay(100); // Add a delay to control the rate of requests sent
            }
        }
    }
}
