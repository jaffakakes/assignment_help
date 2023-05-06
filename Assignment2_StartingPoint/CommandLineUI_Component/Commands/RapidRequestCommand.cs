using CommandLineUI.Presenters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommandLineUI.Commands
{
    public class RapidRequestCommand
    {
        public RapidRequestCommand()
        {
        }

        public async Task<List<string>> ExecuteAsync()
        {
            List<Task<string>> tasks = new List<Task<string>>();

            for (int i = 0; i < 1; i++)
            {
                tasks.Add(Task.Run(() =>
                {
                    return $"test{i}";
                }));
            }

            var results = await Task.WhenAll(tasks);
            return new List<string>(results);
        }
    }
}
