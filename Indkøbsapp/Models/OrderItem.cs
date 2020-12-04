using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indkøbsapp.Models
{
    public class OrderItem : ButikItems
    {
        public OrderItem(ButikItems item)
        {
            this.Price = item.Price;
            this.Billede = item.Billede;
            this.Description = item.Billede;
            this.Navn = item.Billede;
            this.TypeVare = item.TypeVare;
            this.ID = item.ID;
        }
        public int Amount { get; set; }
    }
}
