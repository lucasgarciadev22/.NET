using Delegates.NET.Models;
using System;

namespace Delegates.NET
{
    class Program
    {
        public delegate void Operation(int x, int y);

        static void Main(string[] args)
        {

            Console.WriteLine("Enter a valid name and surname:");

            string name = Console.ReadLine();
            string surname = Console.ReadLine();

            Person person = new Person(name, surname)
            {
                Name = name,
                Surname = surname,
            };

            Console.WriteLine(person.Name + person.Surname);

            Console.WriteLine("Enter a valid month:");
            int month = int.Parse(Console.ReadLine());

            Date date = new Date();

            date.SetMonth(month);

            Console.WriteLine(date.GetMonth());
            Console.WriteLine(date.Month);

            //Operation op = Calculator.Add;
            Operation op = new Operation(Calculator.Add);

            Console.WriteLine("Delegate result:");
            op.Invoke(10, 20);
            //adding more methods to delegate MultiCast Delegates
            op += Calculator.Sub;
            op.Invoke(100, 20);

            Console.WriteLine("Executing event:");
            Maths math = new Maths(50, 50);
            math.Add();

        }

    }
}
