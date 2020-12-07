using System.Collections.Generic;
using Indkøbsapp.Models;

namespace Indkøbsapp.Interfaces
{
    public interface IOrdrer
    {
        public List<IButikItems> Order { get; set; }

        public Bruger Buyer { get; set; }
        public int ID { get; set; }
        public decimal Price { get; set; }

        public void AddItem(IButikItems item);
        public void DeleteItem(int id);
    }
}
