using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramGame
{
    class Program
    {
        static int AskAndCheckNumber()
        {
            int convertedValue;
            string input = Console.ReadLine();
            bool conversionOk = int.TryParse(input, out convertedValue);
            while (!conversionOk || convertedValue <= 0 || convertedValue >= 4)
            {
                Console.WriteLine("You can only insert a number. The number's range are all the selections you can choose in the menu.\n");
                input = Console.ReadLine();
                conversionOk = int.TryParse(input, out convertedValue);
            }
            return convertedValue;
        }

        static void Main(string[] args)
        {
            WordsRepository wordsRepository = new WordsRepository(new FileDictionaryLoader());

            bool check = true;
            while (check)
            {

                Console.Clear();
                Console.WriteLine("Choose");
                Console.WriteLine("1. Training");
                Console.WriteLine("2. Challenge mode (match)");
                Console.WriteLine("3. Exit\n");

                var uiHandler = new ConsoleUiHandler();

                switch (AskAndCheckNumber())
                {
                    case 1:
                        Training training = new Training(wordsRepository);
                        Console.WriteLine(training.Description);
                        training.Run(uiHandler);
                        Console.ReadKey();
                        break;
                    case 2:
                        Challenge challenge = new Challenge(wordsRepository);
                        Console.WriteLine(challenge.Description);
                        challenge.Run(uiHandler);
                        Console.ReadKey();
                        break;
                    case 3:
                        check = false;
                        break;
                }
            }
            
        }
    }

    class ConsoleUiHandler : IUiHandler
    {
        public string AskForString(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
