using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Interfaces;

namespace Indkøbsapp.Models
{
    public class Ordrer : IOrdrer
    {
        public List<IButikItems> Order { get; set; }
        public IBruger Buyer { get; set; }
        public int ID { get; set; }
        public decimal Price { get; set; }
        public int AntalVarerIOdrer { get; set; }
    }
}
