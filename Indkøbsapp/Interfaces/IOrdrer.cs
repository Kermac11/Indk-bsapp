using System.Collections.Generic;
using Indkøbsapp.Models;

namespace Indkøbsapp.Interfaces
{
    public interface IOrdrer
    {
        public List<OrderItem> Order { get; set; }

        public Bruger Buyer { get; set; }
        public int ID { get; set; }
        public double Price { get; set; }
        public int AntalVarerIOdrer { get; set; }

        public void AddItem(IButikItems item);
        public void DeleteItem(int id);
    }
}
