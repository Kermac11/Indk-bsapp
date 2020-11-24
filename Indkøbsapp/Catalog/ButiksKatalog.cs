using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Interfaces;

namespace Indkøbsapp.Catalog
{
    public class ButiksKatalog : IButiksKatalog
    {
        public Dictionary<int, IButikItems> Katalog { get; set; }
        public string ButiksNavn { get; set; }
        public string Lokation { get; set; }

        public ButiksKatalog(string navn, string loakation)
        {
            ButiksNavn = navn;
            Lokation = loakation;
            Katalog = new Dictionary<int, IButikItems>();
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

        public Dictionary<int, IButikItems> FilterIems(string criteria)
        {
            string cl = criteria.ToLower(); 
            Dictionary<int, IButikItems> dl = new Dictionary<int, IButikItems>();
            foreach (IButikItems item in Katalog.Values)
            {
                if (item.Navn.ToLower().StartsWith(cl))
                {
                    dl.Add(item.ID, item);
                }
            }

            return dl;
        }
    }
}
