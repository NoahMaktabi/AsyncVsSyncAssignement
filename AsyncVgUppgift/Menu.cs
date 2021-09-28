using System.Threading;
using System;
using System.Threading.Tasks;

namespace AsyncVgUppgift
{
    public static class Menu
    {
        public static async Task RunMenu()
        {
            const string info = @"
This application shows the difference between asynchronous and synchronous programming.
To demonstrate choose to run program synchronously and then again asynchronously.
You will then notice that the asynchronous program runs a lot faster that the synchronous. Almost twice as fast.
If this was a WPF or Winforms application. The app then would lock itself when running synchronously. 
But now when running asynchronously. 

Press any key to return to main menu...
";
            startLabel:
            var option = ShowMenu();
            switch (option)
            {
                case 1:
                    Console.Clear();
                    var sync = new SyncExecution();
                    sync.Start();
                    "Sync execution is done... Press any key to return to main menu".ShowAnimatedText(20);
                    Console.ReadKey(true);
                    Console.Clear();
                    goto startLabel;


                case 2:
                    Console.Clear();
                    var asyn = new AsyncExecution();
                    await AsyncExecution.Start();
                    "Async execution is done... Press any key to return to main menu".ShowAnimatedText(20);
                    Console.ReadKey(true);
                    Console.Clear();
                    goto startLabel;


                case 3:
                    Console.Clear();
                    info.ShowAnimatedText(5);
                    Console.ReadKey(true);
                    Console.Clear();
                    goto startLabel;


                case 4:
                    "Exit it is. Thank you for using this app.".ShowAnimatedText(10);
                    Environment.Exit(0);
                    break;
            }
        }


        #region MenuHelpers
        private static int ShowMenu()
        {
            "Choose an option: \n1- Run program synchronously.\n2- Run program asynchronously.\n3- Show info about app. \n4- Exit.".ShowAnimatedText(10);
            var input = Console.ReadLine();
            var success = int.TryParse(input, out var result);
            while (!success || !CheckValidNumber(result))
            {
                Console.WriteLine("Invalid input. Write a number between 1 and 4.");
                input = Console.ReadLine();
                success = int.TryParse(input, out result);
            }

            return result;
        }


        private static bool CheckValidNumber(int numberToCheck)
        {
            return numberToCheck is > 0 and < 5;
        }

        #endregion


        #region ExtensionMethods

        
        /// <summary>
        /// Shows the given text in an animated form in console.
        /// </summary>
        /// <param name="text">The text to be animated in console</param>
        /// <param name="animationInMs">How much time in milliseconds between each letter</param>
        public static void ShowAnimatedText(this string text, int animationInMs = 50)
        {
            foreach (var letter in text)
            {
                Console.Write(letter);
                Thread.Sleep(animationInMs);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Print info about the provided website.
        /// The info is how many characters the website contains.
        /// </summary>
        /// <param name="website"></param>
        public static void ReportWebsiteInfo(this WebsiteDataModel website)
        {
            Console.WriteLine($"{website.Url} contains {website.Data.Length} characters which were downloaded. \n");
        }

        #endregion

    }
}