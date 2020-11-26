using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Interfaces;
using Indkøbsapp.Models;

namespace Indkøbsapp.Catalog
{
    public class OrderKatalog : IOrdrerKatalog
    {
        private IDictionary<int, IOrdrer> _katalog;
        public IDictionary<int, IOrdrer> Katalog { get; set; }

        public OrderKatalog()
        {
            Katalog = new Dictionary<int, IOrdrer>();
        }

      

        public void CreateOrder(IOrdrer order)
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

        public IOrdrer FindOrder(int id)
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

        public List<IOrdrer> FindBrugereOrder(IBruger user)
        {
            List<IOrdrer> el = new List<IOrdrer>();
            foreach (IOrdrer item in Katalog.Values)
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
