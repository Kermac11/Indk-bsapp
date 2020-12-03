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
        //Her mangler [REQUIRED og sådan noget
        public VareKategori TypeVare { get; set; }
        [Required]
        public int ID { get; set; }
        public string Navn { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Billede { get; set; }
    }
}
