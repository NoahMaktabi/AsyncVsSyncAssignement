using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncVgUppgift
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            "Hello and welcome to this application that demonstrates the difference between Sync and Async programing".ShowAnimatedText(15);
            Thread.Sleep(1500);
            await Menu.RunMenu();
        }
    }
}
