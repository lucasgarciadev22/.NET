using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //Multidimensional Array
            int[,] matrix = new int[4, 2] //[lines, collumns] dimension [0,1]
            {
                {8,8},{5,5},{4,4},{10,10}
            };

            for (int i = 0; i < matrix.GetLength(0); i++) //lines
            {
                for (int j = 0; j < matrix.GetLength(1); j++) //collumns
                {
                    Console.Write("{ " + matrix[i, j] + " }"); //print entire matrix
                }
                Console.WriteLine();

            }

            //Array operations
            int[] array = new int[5] { 6, 8, 5, 2, 1 };
            int[] array2 = new int[5] { 6, 8, 5, 2, 1 };

            ArrayOperations arrayOperations = new ArrayOperations();

            Console.WriteLine("Original Array");
            arrayOperations.PrintArray(array);

            Console.WriteLine("After BubbleSort");
            arrayOperations.BubbleSort(ref array);
            arrayOperations.PrintArray(array);

            Console.WriteLine("After GenericSort");
            arrayOperations.GenericSort(ref array2);
            arrayOperations.PrintArray(array2);

            Console.WriteLine("Enter a value from the array to find it: ");
            int valueToFind = int.Parse(Console.ReadLine());

            int findedValue = arrayOperations.GetValue(array, valueToFind);

            if (findedValue > 0)
            {
                Console.WriteLine("Finded value: " + findedValue + " at position " + Array.IndexOf(array, findedValue));
            }
            else
            {
                Console.WriteLine("Error");
            }

            Console.WriteLine("Converting array to string . . . ");

            string[] arrayString = arrayOperations.ConvertArrayToString(array);

            for (int i = 0; i < arrayString.Length; i++)
            {

                Console.Write(arrayString[i] + ",");

            }

            Console.WriteLine();

            List<string> states = new List<string>();
            states.Add("SC");
            states.Add("MT");
            states.Add("RS");

            Console.WriteLine($"Quantity os states in the State List: {states.Count}");

            Console.WriteLine();

            foreach (var item in states)
            {
                Console.Write(item + " / ");
            }

            Console.WriteLine();

            for (int i = 0; i < states.Count; i++)
            {
                Console.WriteLine($"Index {i}, State: {states[i]}");
            }
            Console.WriteLine();

            Console.WriteLine("Removing item MT from list: ");

            states.Remove("MT");

            for (int i = 0; i < states.Count; i++)
            {
                Console.WriteLine($"Index {i}, State: {states[i]}");
            }
            Console.WriteLine();

            //adding multiple items in a collection using AddRange
            string[] stateArray = new string[4] { "MG", "MS", "PB", "SE" };

            states.AddRange(stateArray);

            Console.WriteLine("New Array after adding multiple items by AddRange");

            for (int i = 0; i < states.Count; i++)
            {
                Console.WriteLine($"Index {i}, State: {states[i]}");
            }
            Console.WriteLine();

            //queue FIFO and stacks LIFO

            //Queue
            Queue<string> queue = new Queue<string>();

            queue.Enqueue("Person1");
            queue.Enqueue("Person2");
            queue.Enqueue("Person3");

            Console.WriteLine($"Persons in queue: {queue.Count}");

            while (queue.Count > 1)
            {
                Console.WriteLine($"Next person in queue: {queue.Peek()}");
                Console.WriteLine($"{queue.Dequeue()} goes out, now it's {queue.Peek()} turn");
            }

            Console.WriteLine();

            //Stack
            Stack<string> bookStack = new Stack<string>();

            bookStack.Push(".NET Introduction");
            bookStack.Push("Clean Code");
            bookStack.Push("Why Am I The Best Dev?");

            while (bookStack.Count > 1)
            {
                Console.WriteLine($"Next book to collect from stack: '{bookStack.Peek()}'");
                Console.WriteLine($"'{bookStack.Pop()}' was readed...");
                Console.WriteLine();
                Console.WriteLine($"There's {bookStack.Count} more book(s) to read: ");

                foreach (var item in bookStack)
                {
                    Console.Write($"{item}, ");
                }

                Console.WriteLine();
            }
            Console.WriteLine($"'{bookStack.Pop()}' was readed...");
            Console.WriteLine();
            Console.WriteLine("Well done! no more books to read . . . ");

            Console.WriteLine();

            //Dictionary <key any type> , <value any type>
            Dictionary<string, string> cities = new Dictionary<string, string>();

            cities.Add("RJ", "Rio de Janeiro");
            cities.Add("SP", "São Paulo");
            cities.Add("BH", "Belo Horizonte");

            foreach (KeyValuePair<string, string> item in cities) //using KeyValuePair because it's a Dictionary
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }

            //find by key , returning value
            Console.WriteLine("Enter the key of the city you wanna find: ");
            string findKey = Console.ReadLine();

            Console.WriteLine(cities[findKey]);

            //updating value at runtime
            Console.WriteLine("Enter the key of the city you wanna update: ");

            string updateKey = Console.ReadLine();

            Console.WriteLine("Enter the name of the city you wanna update: ");

            string updateName = Console.ReadLine();

            cities[updateKey] = updateName;

            Console.WriteLine();

            foreach (KeyValuePair<string, string> item in cities) //using KeyValuePair because it's a Dictionary
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }

            //Preventing exceptions when finding keys in the dictionary

            Console.WriteLine("Enter the key of the city you wanna find: ");
            string findKeySafe = Console.ReadLine();

            if (cities.TryGetValue(findKeySafe, out string cityResult))
            {
                Console.WriteLine(cityResult);
            }
            else
            {
                Console.WriteLine($"Key {cityResult} doesn't exists");

            }

            Console.WriteLine();
            Console.WriteLine();

            //Using LINQ

            int[] arrayNums = new int[5] { 1, 2, 3, 4, 5 };

            var queryEvenNums =
                from num in arrayNums
                where num % 2 == 0
                orderby num
                select num;

            Console.WriteLine("Even numbers query: "+ string.Join(",",queryEvenNums));

            var evenNums = arrayNums.Where(x => x % 2 == 0).OrderBy(x => x).ToList(); //another method

            Console.WriteLine("Even numbers query: " + string.Join(",", evenNums));

            Console.WriteLine();

            //array distinct dont repeat numbers

        }
    }
}
