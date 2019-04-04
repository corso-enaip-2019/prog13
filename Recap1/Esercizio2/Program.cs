using System;
using System.Linq;

namespace Esercizio2
{
    class Program
    {
        static void Main(string[] args)
        {
            Mum leila = new Mum("Leila");
            Dad hanSolo = new Dad("Han Solo");

            leila.MakeBaby(hanSolo, "Kylo Ren");

            Console.Read();
        }
    }

    abstract class Person
    {

        public Person(string name)
        {
            this.name = name;
        }

        private string name;

        //public string GetName()
        //{
        //    return name;
        //}

        //private void SetName(string value)
        //{
        //    if(string.IsNullOrWhiteSpace(value)) //o posso usare (value == null || value == "" || value.All(c => c == ' '))
        //        throw new ArgumentException("The name cannot be empty or blank");
        //    name = value;
        //}
        
        public string Name
        {
            get
            {
                return Name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("the name cannot be empty or blank");
                Name = value;
            }
        }


    }

    abstract class Parent : Person
    {
        public Parent(string name) : base(name)
        {

        }
        public Baby Child { get; set; }

        public abstract void ComfortChild();

    }
    class Baby : Person
    {
        public Baby(string name)
           : base(name)
        { }

        public void StartCrying()
        {
            Console.WriteLine($"{Name} ha cominciato a piangere");
        }
    }

    class Dad : Parent
    {
        public Dad(string name)
           : base(name)
        { }

        public Baby Child { get; set; }

        public void ComfortChild()
        {

        }
    }

    class Mum : Parent
    {
        public Mum(string name)
           : base(name)
        { }

        public void MakeBaby(Dad dad, string name)
        {
            Baby baby = new Baby(name);
            Child = baby;
            dad.Child = baby;
            Console.WriteLine($"{Name} ha fatto un figlio con {dad.Name}, che si chiama {baby.Name}");
        }

        public Baby Child { get; private set; }

        public void ComfortChild()
        {

        }
    }

}
