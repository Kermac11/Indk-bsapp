using System.Collections.Generic;
using System.Linq;
using Indkøbsapp.Interfaces;
using Indkøbsapp.Models;
using RazorPagesEventMakerIC.Helpers;

namespace Indkøbsapp.Services
{
    public class ButiksVareKatalog : IButiksVareKatalog
    {
        private string filepath = @"Data\JsonVarer.json";

        public string ButiksNavn { get; set; }
        public string Lokation { get; set; }

        public Dictionary<int, ButikItems> GetAllButikVarer()
        {
            Dictionary<int, ButikItems> result = new Dictionary<int, ButikItems>();
            foreach (var vare in JsonVareReader.ReadJson(filepath))
            {
                result.Add(vare.ID, vare);
            }
            return result;
        }
        public ButikItems FindItem(int id)
        {
            if (GetAllButikVarer().ContainsKey(id))
            {
                return GetAllButikVarer()[id];
            }

            return null;
        }

        public void AddItem(ButikItems item)
        {
            List<ButikItems> varer = new List<ButikItems>();
            foreach (var vare in GetAllButikVarer().Values)
            {
                varer.Add(vare);
            }

            if (!GetAllButikVarer().ContainsKey(item.ID))
            {
                varer.Add(item);
            }

            JsonVareWriter.WriteToJson(varer, filepath);
        }

        public void DeleteItem(int id)
        {
            List<ButikItems> varer = new List<ButikItems>();
            foreach (var vare in GetAllButikVarer().Values)
            {
                varer.Add(vare);
            }


            if (GetAllButikVarer().ContainsKey(id))
            {
                ButikItems vareToDelete = null;
                foreach (var item in varer)
                {
                    if (item.ID == id)
                    {
                        vareToDelete = item;
                    }
                }
                varer.Remove(vareToDelete);
            }

            JsonVareWriter.WriteToJson(varer, filepath);
        }

        //public Dictionary<int, IButikItems> SortPrices()
        //{
        //    int placeholder = 0;
        //    Dictionary<int, IButikItems> dl = new Dictionary<int, IButikItems>();
        //    foreach (KeyValuePair<int,IButikItems> item in Katalog.OrderBy(key => key.Value.Price))
        //    {
        //        if (placeholder == 0)
        //        {
        //            dl.Add(0, item.Value);
        //            placeholder += 1;
        //        }
        //        else
        //        {
        //            dl.Add(placeholder, item.Value);
        //            placeholder += 1;
        //        }

        //    }

        //    return dl;
        //}Ved ikke hvad den her skal gøre

        public void EditVare(ButikItems vare)
        {
            if (vare != null)
            {
                List<ButikItems> varer = new List<ButikItems>();

                foreach (var va in GetAllButikVarer().Values)
                {
                    if (va.ID == vare.ID)
                    {
                        va.ID = vare.ID;
                        va.Navn = vare.Navn;
                        va.Price = vare.Price;
                        va.Description = vare.Description;
                        va.TypeVare = vare.TypeVare;
                        va.Butik = vare.Butik;
                        va.Billede = vare.Billede;
                    }
                    varer.Add(va);
                }
                JsonVareWriter.WriteToJson(varer, filepath);
            }
        }
        public List<ButikItems> FilterItems(string criteria)
        {
            List<ButikItems> dl = new List<ButikItems>();
            if (criteria == "" || criteria == null)
            {
                foreach (var item in GetAllButikVarer().Values)
                {
                    dl.Add(item);
                }
            }
            else
            {
                string cl = criteria.ToLower();
                foreach (ButikItems item in GetAllButikVarer().Values)
                {
                    if (item.Navn.ToLower().Contains(cl))
                    {
                        dl.Add(item);
                    }
                }
            }
            return dl;
        }
        public List<ButikItems> FilterButiks(string butik)
        {
            List<ButikItems> dl = new List<ButikItems>();
            if (butik == "" || butik == null)
            {
                foreach (var item in GetAllButikVarer().Values)
                {
                    dl.Add(item);
                }
            }
            else
            {
                string bLower = butik.ToLower();
                foreach (ButikItems item in GetAllButikVarer().Values)
                {
                    if (item.Butik.ToLower().StartsWith(bLower))
                    {
                        dl.Add(item);
                    }
                }
            }
            return dl;
        }
        public List<ButikItems> FilterItemsAndButiks(string criteria, string butik)
        {
            List<ButikItems> dl = new List<ButikItems>();
            string cLower = criteria.ToLower();
            string bLower = butik.ToLower();
            foreach (ButikItems item in GetAllButikVarer().Values)
            {
                if (item.Navn.ToLower().Contains(cLower) && item.Butik.ToLower().StartsWith(bLower))
                {
                    dl.Add(item);
                }
            }
            return dl;
        }
        public List<ButikItems> FilterByEitherItemOrButik(string criteria, string butik)
        {
            List<ButikItems> dl = new List<ButikItems>();
            if (criteria == "" || criteria == null)
            {
                if (butik == "" || butik == null)
                {
                    foreach (var item in GetAllButikVarer().Values)
                    {
                        dl.Add(item);
                    }
                }
                else
                {
                    dl = FilterButiks(butik);
                }
            }
            else
            {
                if (butik == "" || butik == null)
                {
                    dl = FilterItems(criteria);
                }
                else
                {
                    dl = FilterItemsAndButiks(criteria, butik);
                }
            }
            return dl;
        }
    }
}
