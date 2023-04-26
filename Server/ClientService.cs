﻿using System.Net.Sockets;
using System.Text.Json;
using CommandLineUI;
namespace ServerSide
{
    class ClientService
    {

        private static Dictionary<int, List<string>> menuActions = new Dictionary<int, List<string>>()
        {
            { RequestUseCase.VIEW_CURRENT_LOANS, new List<string>(){ "Viewing current loans..." } },
            { RequestUseCase.VIEW_ALL_MEMBERS, new List<string>(){ "Viewing all members..." } },
            { RequestUseCase.VIEW_ALL_BOOKS, new List<string>(){ "Viewing all books..." } },
            { RequestUseCase.BORROW_BOOK, new List<string>(){ "Borrowing a book..." } },
            { RequestUseCase.RETURN_BOOK, new List<string>(){ "Returning a book..." } },
            { RequestUseCase.RENEW_LOAN, new List<string>(){ "Renewing a loan..." } },
            { RequestUseCase.EXIT, new List<string>(){ "Exiting the application..." } }
        };


        private Socket socket;
        private NetworkStream stream;
        public StreamReader reader { get; private set; }
        public StreamWriter writer { get; private set; }

        private RemoveClient removeMe;

        public ClientService(Socket socket, RemoveClient rc)
        {
            this.socket = socket;
            removeMe = rc;
            stream = new NetworkStream(socket);
            reader = new StreamReader(stream, System.Text.Encoding.UTF8);
            writer = new StreamWriter(stream, System.Text.Encoding.UTF8);
        }
        public void InteractWithClient()
        {
            try
            {
                string clientMessage = reader.ReadLine();
                while (clientMessage != null)
                {
                    List<string> response = ProcessClientMessage(clientMessage);
                    writer.WriteLine(JsonSerializer.Serialize(response));
                    writer.Flush();
                    clientMessage = reader.ReadLine();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }

            Close();
            //            Console.WriteLine("Goodbye!");
        }

        private List<string> ProcessClientMessage(string clientMessage)
        {
            Console.WriteLine("Client says: " + clientMessage);
            int key;
            if (int.TryParse(clientMessage, out key) && menuActions.ContainsKey(key))
            {
                return menuActions[key];
            }
            else
            {
                return new List<string>() { "Invalid action key." };
            }
        }


        public void Close()
        {
            try
            {
                removeMe(this);
                socket.Shutdown(SocketShutdown.Both);
            }
            finally
            {
                socket.Close();
            }
        }
    }
}