using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Interfaces;

namespace Indkøbsapp.Models
{
    public class Ordrer : IOrdrer
    {
        public List<OrderItem> Order { get; set; }
        public Bruger Buyer { get; set; }
        public int ID { get; set; }
        public double Price { get; set; }
        public int AntalVarerIOdrer { get; set; }
        public void AddItem(ButikItems item)
        {
            bool exist = false;
            foreach (OrderItem i in Order)
            {
                if (i.ID == item.ID)
                {
                    i.Amount += 1;
                    AntalVarerIOdrer += 1;
                    Price += i.Price;
                    exist = true;
                }
            }

            if (exist == false)
            {
                OrderItem p = new OrderItem(item);
                p.Amount = 1;
                AntalVarerIOdrer += 1;
                Price += p.Price;
                Order.Add(p);
            }
          
        }

        public void DeleteItem(int id)
        {
            OrderItem check = null;
            foreach (OrderItem item in Order)
            {
                if (item.ID == id)
                {
                    check = item;
                    item.Amount -= 1;
                    Price -= item.Price;
                    AntalVarerIOdrer -= 1;
                }
            }

            if (check != null && check.Amount == 1)
            {
                Order.Remove(check);
            }
        }
    }
}
