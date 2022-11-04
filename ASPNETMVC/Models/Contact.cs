using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETMVC.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; } 
        public bool Active { get; set; } 
    }
}