using System;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;
using System.Collections.Generic;
using AssignWpf;
using System.Diagnostics;
using System.Threading.Tasks;

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
        public async Task SendMessage(string message)
        {
            if (writer != null)
            {
                await writer.WriteLineAsync(message);
                await writer.FlushAsync();
            }
        }



        private object lockObject = new object();

        public async Task<List<string>> SendAction(int actionKey, int number1 = 0, int number2 = 0)
        {
            // Create a new Request object
            Request request = new Request
            {
                MenuChoice = actionKey,
                Number1 = number1,
                Number2 = number2
            };
            Debug.WriteLine(request);

            // Serialize the request object to a JSON string
            string requestJson = JsonSerializer.Serialize(request);

            lock (lockObject)
            {
                // Write the JSON string to the stream
                writer.WriteLine(requestJson);
                writer.Flush();
            }

            string response;
            lock (lockObject)
            {
                response = reader.ReadLine();
            }

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