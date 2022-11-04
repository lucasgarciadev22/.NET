using System;
using System.Collections.Generic;

class DIO
{

    static void Main(string[] args)
    {

        int n = int.Parse(Console.ReadLine());
        int p = 1, s = 0;
        int[] GetIntArray(int num)
        {
            List<int> listOfInts = new List<int>();
            while (num > 0)
            {
                listOfInts.Add(num % 10);
                num = num / 10;
            }
            listOfInts.Reverse();
            return listOfInts.ToArray();
        }

        int[] getArray = GetIntArray(n);

        foreach (int num in getArray)
        {
            // TODO: Crie as outras condições necessárias para a resolução do desafio:
            p *= num;
            s += num;
        }

        Console.WriteLine(p - s);
    }
}