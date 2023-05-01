using CommandLineUI.Commands;
namespace ServerSide
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server has started!");
            MyServer srvr = new MyServer();
            ICommandFactory commandFactory = new CommandFactory(); // Create your CommandFactory here

            srvr.Start(commandFactory); // Pass CommandFactory to Start

            srvr.Stop();

            Console.WriteLine("Server has finished!");
        }
    }
}