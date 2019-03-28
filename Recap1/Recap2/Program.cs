using System;

namespace Recap2
{
    class Program
    {
        private static int CheckNumber(bool conversion)
        {
            int n = 0;
            string string1;
            while (!conversion)
            {
                Console.Write("Number not valid. \nReinsert the number: ");
                string1 = Console.ReadLine();
                conversion = int.TryParse(string1, out n);
            }
            return n;
        }
        static void Main(string[] args)
        {
            int rangeMin;
            int rangeMax;
            string strings;

            
            Console.Write("Insert 2 numbers and I'll give you all traingular numbers in that range: \nGive me the minimum: ");
            strings = Console.ReadLine();
            int.TryParse(strings, out rangeMin);

            Console.Write("Give me the maximum: ");
            strings = Console.ReadLine();
            int.TryParse(strings, out rangeMax);

            
            int n = 1;
            int triangular = n * (n + 1) / 2;

            for (n = 1; triangular <= rangeMax; n++)
            {
                if (triangular >= rangeMin)
                {
                    Console.WriteLine($"Triangular: {triangular} - its number: {n-1}");
                }
                triangular = n * (n + 1) / 2;
            }
            Console.ReadKey();
        }
    }
}
