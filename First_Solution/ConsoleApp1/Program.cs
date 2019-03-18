using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        /// <summary>
        /// Mostra all'utente il messaggio e prova a convertire il valore di input in un intero
        /// </summary>
        /// <param name="messageForUser"></param>
        /// <returns></returns>
        /// 

        static bool isTriangle(int lato1, int lato2, int lato3)
        {
            bool tr;
            if ((lato1 < (lato2 + lato3)) &&
                (lato2 < (lato1 + lato3)) &&
                (lato3 < (lato2 + lato1)) &&
                (lato1 > Math.Abs(lato2 - lato3)) &&
                (lato2 > Math.Abs(lato1 - lato3)) &&
                (lato3 > Math.Abs(lato1 - lato2)))
            {
                tr = true;
            }
            else
            {
                tr = false;
            }
            return tr;
        }

        static int[] decreaseTriangleSide(int a, int b, int c)
        {
            int[] tr = new int[3];
            tr[0] = a;
            tr[1] = b;
            tr[2] = c;
            Array.Sort(tr);
            Array.Reverse(tr);

            do
            {
                tr[0]--;
                if (tr[0] < tr[1])
                    tr[1]--;
            } while(isTriangle(tr[0],tr[1],tr[2]) == false);

            return tr;
        }

        static int AskAndCheckNumber (string messageForUser)
         {
            int convertedValue;
            Console.WriteLine(messageForUser);
            string input = Console.ReadLine();
            bool conversionOk = int.TryParse(input, out convertedValue); //out a è l'output del metodo nel caso lo mettessi come intero
            while (!conversionOk || convertedValue <= 0)
            {
                Console.WriteLine("You can insert only positive numbers");
                input = Console.ReadLine();
                conversionOk = int.TryParse(input, out convertedValue);
            }
            return convertedValue;
        }

        static void Main(string[] args)
        {
            //Scrivere su console
            //Console.WriteLine("Riga");
            //Input da utente -- Readline per una riga intera
            // Console.ReadLine();
            //tipi di variabli -- u per undefined (davanti ai nativi, es. uint -- solo positivi) -- short, long e decimal per numeri interi -- decimal
            //se voglio creare una string da due mai fare str = str + "parola" ma utilizzare i metodi di string --> string.Concat(str, "parola")
            //classe Math per operazioni matematiche
            //far inserire all'utente 3 numeri

            int[] lati = new int[3];
            for (int i = 0; i < lati.Length; i++)
            {
                lati[i] = AskAndCheckNumber(String.Concat("Insert side ", i+1));
            }

            if (isTriangle(lati[0], lati[1], lati[2]))
            {
                Console.WriteLine("It's a triangle");
            }
            else
            {
                Console.WriteLine("It's not a triangle, here's a possible one -->\n");
                lati = decreaseTriangleSide(lati[0], lati[1], lati[2]);
                Console.WriteLine(String.Concat(lati[0], " " , lati[1], " ", lati[2]));
                
            }
            Console.ReadKey();

        }
    }
}
