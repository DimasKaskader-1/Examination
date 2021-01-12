using System;
using System.Threading;
using System.Threading.Tasks;

namespace Exammt
{
    class Program
    {
        static void Main (string[] args)
        
        {
            while (true)
            {

                var input = Console.ReadLine();
                var cancelTokenSource = new CancellationTokenSource();
                Task.Run(() => Delay(input, cancelTokenSource.Token));
                do
                {
                }
                while (Console.ReadLine() != "");



                cancelTokenSource.Cancel();
            }
        }

        private static async Task Delay(string input, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                Console.WriteLine(input);
                await Task.Delay(1000);
            }
        }
    }
}
