using System;

namespace DesafiosDeCódigo
{
    class Program
    {
        static void Main(string[] args)

        {
            // #1 Challenge
            Console.WriteLine("Type both numbers to divide separated by '/'(and press Enter): ");
            char[] split = { '/' };
            string[] line = Console.ReadLine().Split(split);

            double x = double.Parse(line[0]);
            double y = double.Parse(line[1]);
            if (y == 0)
            {
                Console.WriteLine("Imposible division");
            }
            else
            {
                double division = x / y;
                Console.WriteLine(division.ToString("N1"));
            }


            //#2 Challenge
            Console.WriteLine("The following code will calculate how many minutes a bike will take to run the input distance (in km), considering that " +
                "the bike speed is about the double of the other bike");
        
            Console.WriteLine("Type the distance in Km (and press Enter): ");
            int km = int.Parse(Console.ReadLine());
            int min = km * 2;
            Console.WriteLine(min + " minutes");


            //#3 Challenge
            Console.WriteLine("The following program will read the how many portions (int) each person will consume. Analyzing by food consumption in gr, from this 6 persons,  " +
                "the code will calculate how many food in gr is necessary to feed all this people");
            Console.WriteLine("Enter person 1 portion's quantity (int):");
            int chico = 300 * int.Parse(Console.ReadLine());
            Console.WriteLine("Enter person 2 portion's quantity (int):");
            int bento = 1500 * int.Parse(Console.ReadLine());
            Console.WriteLine("Enter person 3 portion's quantity (int):");
            int bernardo = 600 * int.Parse(Console.ReadLine());
            Console.WriteLine("Enter person 4 portion's quantity (int):");
            int marina = 1000 * int.Parse(Console.ReadLine());
            Console.WriteLine("Enter person 5 portion's quantity (int):");
            int iara = 150 * int.Parse(Console.ReadLine());
            Console.WriteLine("Enter person 6 portion's quantity (int):");
            int marlene = 225 * int.Parse(Console.ReadLine());

            int total = chico + bento + bernardo + marina + iara;
            Console.WriteLine("The amount of food necessary to feed this 6 people is:");
            Console.WriteLine(total + " gr");

        }
    }
}
