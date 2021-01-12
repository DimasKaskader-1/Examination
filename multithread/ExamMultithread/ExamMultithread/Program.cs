using System;
using System.Threading;
using System.Threading.Tasks;

namespace ExamMultithread
{
    class Program
    {
        static AutoResetEvent auto_reset_event = new AutoResetEvent(true);
        static string temp;

        static async void TaskWrite()
        {
            while (true)
            {
                auto_reset_event.WaitOne();
                Console.WriteLine(temp);
                auto_reset_event.Set();
                await Task.Delay(1000);
            }
        }
        static void Main(string[] args)
        {
            temp = Console.ReadLine();
            Task.Run(() => TaskWrite());
            while (true)
            {

                if (Console.ReadLine() == "")
                {
                    auto_reset_event.WaitOne();
                    temp = Console.ReadLine();
                    auto_reset_event.Set();
                }
            }

        }


    }
}