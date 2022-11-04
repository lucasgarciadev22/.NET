using System;

namespace Delegates.NET.Models
{

    public class Calculator
    {
        //Delegate
        public delegate void DelegateCalculator();
        //Event -> refers Delegate
        public static event DelegateCalculator EventCalculator;

        public static void Add(int x, int y)
        {
            if (EventCalculator != null)
            {
                Console.WriteLine($"Operation -> Add : ({x + y})");
                EventCalculator();//execute all event methods

            }
            else
            {
                Console.WriteLine("No data received");
            }
        }

        public static void Sub(int x, int y)
        {
            Console.WriteLine($"Operation -> Sub : ({x - y})");
        }
    }
}
