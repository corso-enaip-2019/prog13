using System;
using System.Collections.Generic;

namespace Esercizio3
{
    class Program
    {
        static void ShowIntList(List<int> a)
        {
            for(int i = 0; i < a.Count; i++)
            {
                Console.Write($"{a[i]}\n");
            }
        }

        static void ShowStringList(List<string> a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                Console.Write($"{a[i]}\n");
            }
        }

        static void Main(string[] args)
        {
            //input lista di stringhe (nel main)
            //due operazioni di proiezioni della lista --> da una lista di stringhe devo tirare fuori un'altra lista di stringhe con le parole ribaltate
            //--> da una lista di stringhe devo ottenere una lista di interi con la lunghezza delle stringhe
            //3 funzionalità di filtro --> stringhe con lunghezza < 3
            //stringhe che iniziano per a
            //stringhe convertibile in int

            List<string> stringCopyList = new List<string>();
            List<int> intCopyList = new List<int>();

            List<string> stringList = new List<string>
            {
                "123",
                "132",
                "artemide",
                "1436",
                "546",
                "ciao",
                "sa",
                "ai",
                "provauno",
                "provadue",
                "provatre"
            };

            Filter f = new Filter();
            ProjectionsOps pjops = new ProjectionsOps();

            stringCopyList = pjops.ReverseStringList(stringList);

            ShowStringList(stringCopyList);
            Console.WriteLine();

            intCopyList = pjops.StringLenghtsList(stringList);

            ShowIntList(intCopyList);
            Console.WriteLine();

            stringCopyList = f.FirstFilter(stringList);

            ShowStringList(stringCopyList);
            Console.WriteLine();

            stringCopyList = f.SecondFilter(stringList);

            ShowStringList(stringCopyList);
            Console.WriteLine();

            stringCopyList = f.ThirdFilter(stringList);

            ShowStringList(stringCopyList);
            Console.WriteLine();

            Console.Read();


        }
    }

    class ProjectionsOps
    {
        public List<string> ReverseStringList(List<string> stringList)
        {
            List<string> returningStringList = new List<string>();
            char[] charArray;
            for (int i = 0; i < stringList.Count; i++)
            {
                charArray = stringList[i].ToCharArray();
                Array.Reverse(charArray);
                returningStringList.Add(new string(charArray));
            }
            
            return returningStringList;
        }

        public List<int> StringLenghtsList(List<string> stringList)
        {
            List<int> returningIntList = new List<int>();

            foreach (string s in stringList)
                returningIntList.Add(s.Length);
            //for (int i = 0; i < stringList.Count; i++)
            //{
            //    lenght = stringList[i].Length;
            //    returningIntList.Add(lenght);
            //}

            return returningIntList;
        }
    }

    class Filter
    {
        public List<string> FirstFilter(List<string> stringList)
        {
            List<string> returningList = new List<string>();

            for(int i = 0; i < stringList.Count; i++)
            {
                if(stringList[i].Length < 3)
                {
                    returningList.Add(stringList[i]);
                }
            }

            return returningList;
        }

        public List<string> SecondFilter(List<string> stringList)
        {
            List<string> returningList = new List<string>();

            for (int i = 0; i < stringList.Count; i++)
            {
                if (stringList[i].Substring(0, 1).Equals("a"))
                {
                    returningList.Add(stringList[i]);
                }
            }
            return returningList;
        }

        public List<string> ThirdFilter(List<string> stringList)
        {
            List<string> returningList = new List<string>();

            for (int i = 0; i < stringList.Count; i++)
            {
                if (int.TryParse(stringList[i], out int _))
                {
                    returningList.Add(stringList[i]);
                }
            }
            return returningList;
        }
    }
}
