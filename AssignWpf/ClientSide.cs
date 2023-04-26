﻿using System;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;
using System.Collections.Generic;

namespace ClientSide
{
    public class ServerConnection
    {
        private string serverAddress;
        private int serverPort;
        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;

        public ServerConnection(string serverAddress, int serverPort)
        {
            this.serverAddress = serverAddress;
            this.serverPort = serverPort;
        }

        public void Connect()
        {
            client = new TcpClient(serverAddress, serverPort);
            NetworkStream stream = client.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);
        }

        public List<string> SendAction(int actionKey)
        {
            writer.WriteLine(actionKey);
            writer.Flush();

            string response = reader.ReadLine();
            if (response != null)
            {
                return JsonSerializer.Deserialize<List<string>>(response);
            }
            else
            {
                return new List<string> { "Error: No response from the server." };
            }
        }

        public void Disconnect()
        {
            reader.Dispose();
            writer.Dispose();
            client.Close();
        }
    }
}