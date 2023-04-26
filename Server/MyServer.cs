using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ServerSide
{
    delegate void RemoveClient(ClientService c);

    class MyServer
    {
        private TcpListener tcpListener;
        private List<ClientService> clientServices;

        public MyServer()
        {
            IPAddress ipAddress = IPAddress.Loopback;
            tcpListener = new TcpListener(ipAddress, 4444);
            clientServices = new List<ClientService>();
            Console.WriteLine("Listening....");
        }

        public void Start()
        {
            tcpListener.Start();

            while (true)
            {
                Socket s = tcpListener.AcceptSocket();  //blocks until a connection is made
                ClientService clientService = new ClientService(s, RemoveClient);
                clientServices.Add(clientService);
                Task.Run(clientService.InteractWithClient);
            }
        }

        public void Stop()
        {
            tcpListener.Stop();
        }

        private void RemoveClient(ClientService c)
        {
            //Console.WriteLine("REMOVING CLIENT");
            clientServices.Remove(c);
        }

    }
}