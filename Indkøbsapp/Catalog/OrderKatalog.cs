using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Interfaces;
using Indkøbsapp.Models;
using Indkøbsapp.Services;

namespace Indkøbsapp.Catalog
{
    public class OrderKatalog : IOrdrerKatalog
    {
        private Dictionary<int, Ordrer> _katalog;
        public Dictionary<int, Ordrer> Katalog { get; set; }

        public OrderKatalog()
        {
            Katalog = new Dictionary<int, Ordrer>();
        }

      

        public void CreateOrder(Ordrer order)
        {
            if (Katalog.Count == 0)
            {
                order.ID = 0;
            }
            else
            {
                order.ID = Katalog.Count + 1;
            }
            Katalog.Add(order.ID,order);
        }

        public Ordrer FindOrder(int id)
        {
            if (Katalog.ContainsKey(id))
            {
                return Katalog[id];
            }

            return null;
        }

        public void DeleteOrder(int id)
        {
            if (Katalog.ContainsKey(id))
            {
                Katalog.Remove(id);
            }
        }

        public List<Ordrer> FindBrugereOrder(Bruger user)
        {
            List<Ordrer> el = new List<Ordrer>();
            foreach (Ordrer item in Katalog.Values)
            {
                if (item.Buyer == user)
                {
                    el.Add(item);
                }
            }

            return el;
        }
    }
}
