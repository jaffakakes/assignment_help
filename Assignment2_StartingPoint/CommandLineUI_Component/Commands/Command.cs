namespace CommandLineUI.Commands
{
   public interface Command
    {
        void Execute();
        string GetResult();
    }
}
