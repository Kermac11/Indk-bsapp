using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Interfaces;
using Indkøbsapp.Models;

namespace Indkøbsapp.Catalog
{
    public class ButiksKatalog : IButiksKatalog
    {
        private Dictionary<int, IButikItems> Katalog;
        public string ButiksNavn { get; set; }
        public string Lokation { get; set; }

        public ButiksKatalog()
        {
            Katalog = new Dictionary<int, IButikItems>();
            Katalog.Add(1,new ButikItems(1,"fdb",0.2,0));
            Katalog.Add(2,new ButikItems(2,"cwecv",5.2,(VareKategori) 2));
        }
        public IButikItems FindItem(int id)
        {
            if (Katalog.ContainsKey(id))
            {
                return Katalog[id];
            }

            return null;
        }

        public void AddItem(IButikItems item)
        {
            Katalog.Add(item.ID,item);
        }

        public void DeleteItem(int id)
        {
            Katalog.Remove(id);
        }

        public Dictionary<int, IButikItems> SortPrices()
        {
            int placeholder = 0;
            Dictionary<int, IButikItems> dl = new Dictionary<int, IButikItems>();
            foreach (KeyValuePair<int,IButikItems> item in Katalog.OrderBy(key => key.Value.Price))
            {
                if (placeholder == 0)
                {
                    dl.Add(0, item.Value);
                    placeholder += 1;
                }
                else
                {
                    dl.Add(placeholder, item.Value);
                    placeholder += 1;
                }

            }

            return dl;
        }

        public List<IButikItems> FilterItems(string criteria)
        {
            List<IButikItems> dl = new List<IButikItems>();
            if (criteria == "" || criteria == null)
            {
                foreach (var item in Katalog.Values)
                {
                    dl.Add(item);
                }
            }
            else
            {
                string cl = criteria.ToLower();
                foreach (IButikItems item in Katalog.Values)
                {
                    if (item.Navn.ToLower().StartsWith(cl))
                    {
                        dl.Add(item);
                    }
                }
            }
            return dl;
        }

        public Dictionary<int,IButikItems> GetAllButikItems()
        {
            return Katalog;
        }
    }
}
