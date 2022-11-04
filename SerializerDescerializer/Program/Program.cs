using Newtonsoft.Json;
using Program.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Sell sell = new Sell(1, "Office Supply", 29.99M);

            string serialized = JsonConvert.SerializeObject(sell, Formatting.Indented);

            File.WriteAllText(@"Files/sells.json", serialized);

            Console.WriteLine(serialized);

            List<Sell> sellsList = new List<Sell>();
            Sell sellsAgain = new Sell(2, "Computer Supply", 189.90M);

            sellsList.Add(sell);
            sellsList.Add(sellsAgain);

            serialized = JsonConvert.SerializeObject(sellsList, Formatting.Indented);

            File.WriteAllText(@"Files/sellsAgain.json", serialized);

            serialized = File.ReadAllText(@"Files/sellsAgain.json");

            List<Sell> deserializedList = JsonConvert.DeserializeObject<List<Sell>>(serialized);

            var anonimousList = deserializedList.Select(x => new { x.Product, x.Price });

            foreach (var anonimousProp in anonimousList)
            {
                Console.WriteLine($"Product: {anonimousProp.Product}   Price; {anonimousProp.Price}");
            }
        }
    }
}
