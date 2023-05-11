
using ClientSide;
using AssignWpf.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

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

            List<Task> tasks = new List<Task>();

            for (int i = 1; i <= 20; i++)
            {
                tasks.Add(serverConnection.SendAction(3, 1, 1));
            }

            await Task.WhenAll(tasks);

        }

       
    }
}
