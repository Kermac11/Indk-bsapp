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
        public double Price
        {
            get
            {
                return Price;
            }
            set{}
        }
        public int AntalVarerIOdrer { get; set; }

        public Ordrer()
        {
            Order = new List<OrderItem>();
        }
        public void AddItem(ButikItems item)
        {
            bool exist = false;
            foreach (OrderItem i in Order)
            {
                if (i.ID == item.ID)
                {
                    i.Amount += 1;
                    AntalVarerIOdrer += 1;
                    exist = true;
                }
            }

            if (exist == false)
            {
                OrderItem p = new OrderItem(item);
                p.Amount = 1;
                AntalVarerIOdrer += 1;
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
                    AntalVarerIOdrer -= 1;
                }
            }

            if (check != null && check.Amount == 1)
            {
                Order.Remove(check);
            }
        }

        public double CalculatePrice()
        {
            foreach (OrderItem item in Order)
            {
                Price = item.Amount * item.Price;
            }

            return Price;
        }
    }
}
