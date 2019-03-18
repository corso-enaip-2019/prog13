using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class StudentDictionaryExample
    {
        //numero di classi presenti nella scuola
        const int numberOfClasses = 5;

        const char insertData = '1';
        const char printAllClasses = '2';
        const char printSelectedClass = '3';
        const char searchStudentClass = '4';
        const char removeStudent = '5';
        const char quitApplication = '6';

        //creo una lista di stringhe per ogni classe, ognuna delle quale ho assegnato un numero
        static Dictionary<int, List<string>> CreateClassRegistry()
        {
            Dictionary<int, List<string>> registry = new Dictionary<int, List<string>>();
            
            for (int i = 0; i < numberOfClasses; i++)
            {
                registry.Add(i, new List<string>());
            }

            return registry;
        }

        static char getMenu()
        {
            char option;

            do
            {
                Console.WriteLine("Choose option/n");
                Console.WriteLine("1. Insert data");
                Console.WriteLine("2. Print all classes");
                Console.WriteLine("3. Print single class");
                Console.WriteLine("4. Search student's class");
                Console.WriteLine("5. Remove student");
                Console.WriteLine("6. Quit");

                option = Console.ReadLine()[0];
            }
            while (option < insertData || option > quitApplication);

            return option;
        }

        static void insertStudentAndClass(Dictionary<int, List<string>> registry)
        {
            string name;
            int classNum;

            do
            {
                Console.WriteLine("Insert the student's name (Press enter for exit input...)/n");

                name = Console.ReadLine();
                if (!name.Equals(""))
                {
                    classNum = insertClass();
                }

            } while (!name.Equals(""));
        }

        static int insertClass()
        {
            int classNum;
            bool result = false;

            do
            {
                Console.WriteLine("Insert the student's class/n");
                result = int.TryParse(Console.ReadLine(), out classNum);

                if (!result || classNum < 1 || classNum > numberOfClasses)
                {
                    Console.WriteLine($"The value of the class is invalid (must be: 1 <= class <= {numberOfClasses})./n");
                }
            } while (!result || classNum < 1 || classNum > numberOfClasses);

            return classNum;
        }
        static void Main(string[] args)
        {
            char option;
            Dictionary<int, List<string>> registry = CreateClassRegistry();

            option = getMenu();

            do
            {
                switch(option)
                {
                    case insertData:
                        insertStudentAndClass(registry);
                        break;
                    case printAllClasses:

                        break;
                    case printSelectedClass:
                        break;
                    case searchStudentClass:
                        break;
                    case removeStudent:
                        break;

                }
            } while (option != quitApplication);
        }
    }
}
