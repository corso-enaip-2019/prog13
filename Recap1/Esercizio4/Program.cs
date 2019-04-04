using System;
using System.Collections.Generic;

namespace Esercizio4
{
    class Program
    {
        static void ShowSmartphoneList(List<Smartphone> a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                Console.Write($"Model: {a[i].Model} - Version: {a[i].Version} - Color: {a[i].Color} - Cost: {a[i].Cost}\n");
            }
        }

        static List<Smartphone> InitializeList()
        {
            List<Smartphone> MockSmartphone = new List<Smartphone>();

            Smartphone s1 = new Smartphone();
            Smartphone s2 = new Smartphone();
            Smartphone s3 = new Smartphone();
            Smartphone s4 = new Smartphone();
            Smartphone s5 = new Smartphone();

            s1.Color = "Blue";
            s2.Color = "Grey";
            s3.Color = "Black";
            s4.Color = "Blue";
            s5.Color = "White";

            s1.Cost = 400.00;
            s2.Cost = 500.00;
            s3.Cost = 699.00;
            s4.Cost = 299.00;
            s5.Cost = 300.00;

            s1.Version = 2.2;
            s2.Version = 1.1;
            s3.Version = 1.5;
            s4.Version = 2.0;
            s5.Version = 2.3;

            s1.Model = "Galaxy";
            s2.Model = "Bean";
            s3.Model = "Premium";
            s4.Model = "Large";
            s5.Model = "Large";


            MockSmartphone.Add(s1);
            MockSmartphone.Add(s2);
            MockSmartphone.Add(s3);
            MockSmartphone.Add(s4);
            MockSmartphone.Add(s5);

            return MockSmartphone;
        }

        static void Main(string[] args)
        {
            List<Smartphone> MockSmartphone = InitializeList();

            IEnumerable<Smartphone> blue = Operations.Filter<Smartphone>(MockSmartphone, new FilterBlue());

            foreach(Smartphone smart in blue)
                Console.Write($"Model: {smart.Model} - Version: {smart.Version} - Color: {smart.Color} - Cost: {smart.Cost}\n");
            //ShowSmartphoneList(colors);

            //Console.WriteLine();
            //ShowSmartphoneList(Operations.FilterCost(MockSmartphone, 500.00));

            Console.Read();
        }
    }

    class Smartphone
    {
        public double Version { get; set; }
        public double Cost { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }

    }

    static class Operations
    {
        //static public List<Smartphone> FilterColor(List<Smartphone> list, string color)
        //{
        //    List<Smartphone> ReturnSmartphone = new List<Smartphone>();
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        if (list[i].Color.Equals(color))
        //            ReturnSmartphone.Add(list[i]);
        //    }
        //    return ReturnSmartphone;
        //}

        //static public List<Smartphone> FilterCost(List<Smartphone> list, double cost)
        //{
        //    List<Smartphone> ReturnSmartphone = new List<Smartphone>();
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        if (list[i].Cost < cost)
        //            ReturnSmartphone.Add(list[i]);
        //    }
        //    return ReturnSmartphone;
        //}

        public static IEnumerable<T> Filter<T>(IEnumerable<T> input, IFilter<T> condition)
        {
            List<T> output = new List<T>();
            foreach (T item in input)
                if (condition.Filter(item))
                    output.Add(item);
            return output;
        }

        //public static IEnumerable<Smartphone> Filter<Smartphone>(IEnumerable<Smartphone> input, IFilter<Smartphone> condition)
        //{
        //    List<Smartphone> output = new List<Smartphone>();
        //    foreach (Smartphone item in input)
        //        if (condition.Filter(item))
        //            output.Add(item);
        //    return output;
        //}
    }

    class FilterBlue : IFilter<Smartphone>
    {
        public bool Filter(Smartphone s)
        {
            return s.Color.Equals("Blue");
        }
    }

    class FilterFromCost : IFilter<Smartphone>
    {
        public bool Filter(Smartphone s)
        {
            return s.Cost < 500.00;
        }
    }

    interface IFilter<T>
    {
        bool Filter(T item);
    }
    
}
