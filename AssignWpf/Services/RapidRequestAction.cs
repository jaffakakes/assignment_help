
using ClientSide;
using AssignWpf.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Threading;

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
            SemaphoreSlim semaphore = new SemaphoreSlim(10);  // adjust this number to your needs
            List<Task> tasks = new List<Task>();

            for (int i = 1; i <= 100; i++)
            {
                await semaphore.WaitAsync();
                tasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        await serverConnection.SendAction(3, 1, 1);
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                }));
            }

            await Task.WhenAll(tasks);
        }


    }
}
