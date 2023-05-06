using System.Net.Sockets;
using System.Text.Json;
using CommandLineUI;
using CommandLineUI.Commands;
using System.Diagnostics;
using Mysqlx;
using Server;

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
            { RequestUseCase.Rapid_Request, new List<string>(){ "Rapid Request..." } },
            { RequestUseCase.RENEW_LOAN, new List<string>(){ "Renewing a loan..." } },
            { RequestUseCase.EXIT, new List<string>(){ "Exiting the application..." } }
        };


        private Socket socket;
        private NetworkStream stream;
        public StreamReader reader { get; private set; }
        public StreamWriter writer { get; private set; }
        private RemoveClient removeMe;
        private ICommandFactory commandFactory;

        public ClientService(Socket socket, RemoveClient rc, ICommandFactory commandFactory)
        {
            this.socket = socket;
            removeMe = rc;
            stream = new NetworkStream(socket);
            reader = new StreamReader(stream, System.Text.Encoding.UTF8);
            writer = new StreamWriter(stream, System.Text.Encoding.UTF8);
            this.commandFactory = commandFactory;
        }
        public void InteractWithClient()
        {
            try
            {
                string clientMessage = reader.ReadLine();
                while (clientMessage != null)
                {
                    List<string> response = ProcessClientMessage(clientMessage);
                    if (response != null)
                    {
                        writer.WriteLine(JsonSerializer.Serialize(response));
                        writer.Flush();
                    }
                    clientMessage = reader.ReadLine();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }

            Close();
            
        }

        public List<string> ProcessClientMessage(string clientMessage)
        {
            Console.WriteLine("Client says: " + clientMessage);

            if (clientMessage.StartsWith("Rapid request"))
            {
                // Display the received rapid request message and don't send a response
                Console.WriteLine(clientMessage);
                return null;
            }

            var clientData = JsonSerializer.Deserialize<ClientMessage>(clientMessage);
            var key = clientData.MenuChoice;
            if (menuActions.ContainsKey(key))
            {
                Debug.WriteLine(key);
                Debug.WriteLine(clientData.Number1);
                Debug.WriteLine(clientData.Number2);

                // Create and execute the command
                Command command = commandFactory.CreateCommand(key, clientData.Number1, clientData.Number2);
                command.Execute();
                string result = command.GetResult();
                


                // Return the result of the command
                return new List<string>() { result };
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