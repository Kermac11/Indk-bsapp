using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Interfaces;

namespace Indkøbsapp.Models
{
    public class ButikItems : IButikItems
    {
        public ButikItems()
        {
            
        }

        public ButikItems(VareKategori type, int id, string navn, double price, string description, string butik)
        {
            TypeVare = type;
            ID = id;
            Navn = navn;
            Price = price;
            Description = description;
            Butik = butik;
        }
        public ButikItems(VareKategori type, int id, string navn, double price, string description, string butik, string billede)
        {
            TypeVare = type;
            ID = id;
            Navn = navn;
            Price = price;
            Description = description;
            Butik = butik;
            Billede = billede;
        }
        public VareKategori TypeVare { get; set; }
        [Required]
        public int ID { get; set; }
        public string Navn { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Billede { get; set; }
        public string Butik { get; set; }
    }
}
