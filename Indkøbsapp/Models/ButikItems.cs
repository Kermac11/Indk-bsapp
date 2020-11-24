using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Interfaces;

namespace Indkøbsapp.Models
{
    public class ButikItems : IButikItems
    {
        public ButikItems(int id, string navn, decimal price)
        {
            ID = id;
            Navn = navn;
            Price = price;
        }
        public int ID { get; set; }
        public string Navn { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Billede { get; set; }
    }
}
