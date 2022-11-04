namespace Delegates.NET.Models
{
    //class with validation on getter and setter
    public class Date
    {
        private int month;

        public int Month { get; set; }

        public int GetMonth()
        {
            return this.month;
        }

        public void SetMonth(int month)
        {
            if (month > 0 && month <= 12)
            {
                this.month = month;
                Month = month;
            }
            else
            {
                System.Console.WriteLine("Invalid month!");
            }
        }
    }
}
