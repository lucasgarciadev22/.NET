using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Models
{
    class Sell
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public decimal Price { get; set; }

        public Sell(int id, string product, decimal price)
        {
            Id = id;
            Product = product;
            Price = price;
        }
    }
}
