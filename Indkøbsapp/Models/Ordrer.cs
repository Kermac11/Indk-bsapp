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
        public Bruger Buyer { get; set; }
        public int ID { get; set; }
        public decimal Price { get; set; }
        public void AddItem(IButikItems item)
        {
            Order.Add(item);
        }

        public void DeleteItem(int id)
        {
            IButikItems check = null;
            foreach (IButikItems item in Order)
            {
                if (item.ID == id )
                {
                    check = item;
                }   
            }

            if (check != null)
            {
                Order.Remove(check);
            }
        }
    }
}
