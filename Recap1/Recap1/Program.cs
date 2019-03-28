using System;

namespace Recap1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Insert a string: ");
            string input = Console.ReadLine();

            bool isPalindrom = IsPalindromeWithCycleTwoValues(input);

            if (isPalindrom)
                Console.WriteLine("The word is a palindrom.");
            else
                Console.WriteLine("Not a palindrom.");
            /*int[] arrayInt = new int[5];

            for(int i = 0; i < 5; i++)
            {
                arrayInt[i] = 1;
            }

            increment(arrayInt);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{arrayInt[i]} - ");
            }
            Console.ReadKey();
        }

        static void increment(int[] array)
        {
            array[3]++;
        */
            Console.Read();
        }

        private static bool IsPalindromeWithCycleTwoValues(string input)
        {
            for (int i = 0, j = input.Length - 1; i <= j; i++, j--)
            {
                Console.WriteLine($"in i: {input[i]} - in j: {input[j]}");
                if(input[i] != input[j])
                    return false;
            }
            return true;
        }

        private static bool IsPalindromeWithCycleOnevalue(string input)
        {
            for (int i = 0; i < input.Length / 2; i++)
                if (input[i] != input[input.Length - i - 1])
                    return false;
            return true;
        }

        private static bool IsPalindroemRecursive(string input)
        {
            if (input.Length < 2)
                return true;
            if (input[0] != input[input.Length - 1])
                return false;

            string newInput = input.Substring(1, input.Length - 2);

            return IsPalindroemRecursive(newInput);
        }
        
    }
}
