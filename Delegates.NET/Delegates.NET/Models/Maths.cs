namespace Delegates.NET.Models
{
    public class Maths
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Maths(int x, int y)
        {
            X = x;
            Y = y;
            //calling event inside external class
            Calculator.EventCalculator += EventHandler;
        }

        public void Add()
        {
            Calculator.Add(X, Y);//passing props to external method
        }

        public void EventHandler()
        {
            System.Console.WriteLine("Calc done!");
        }
    }
}
