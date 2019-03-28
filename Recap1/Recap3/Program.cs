using System;

namespace Recap3
{
    class Program
    {
        static bool IsPrime(int n)
        {
            if (n < 2)
                return false;
            for(int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        static int AskAndCheckNumber(string messageForUser)
        {
            int convertedValue;
            Console.WriteLine(messageForUser);
            string input = Console.ReadLine();
            bool conversionOk = int.TryParse(input, out convertedValue);
            while (!conversionOk || convertedValue <= 0)
            {
                Console.WriteLine($"You can insert only positive numbers\n{messageForUser}");
                input = Console.ReadLine();
                conversionOk = int.TryParse(input, out convertedValue);
            }
            return convertedValue;
        }

        static void Main(string[] args)
        {
            int primesCycle = 0;
            int numberInCheck = 0;
            int input = AskAndCheckNumber("Insert the first n prime numbers you want to see: ");

            while(primesCycle < input)
            {
                if (IsPrime(numberInCheck))
                {
                    Console.WriteLine($"{primesCycle + 1} - {numberInCheck}");
                    primesCycle++;
                }
                    
                numberInCheck++;
            }
            Console.Read();

        }
    }
}
