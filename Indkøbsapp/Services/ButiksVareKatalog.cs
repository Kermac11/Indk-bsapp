using System.Collections.Generic;
using System.Linq;
using Indkøbsapp.Interfaces;
using Indkøbsapp.Models;
using RazorPagesEventMakerIC.Helpers;

namespace Indkøbsapp.Services
{
    public class ButiksVareKatalog : IButiksVareKatalog
    {
        public string filepath { get; set; } = @"Data\JsonVarer.json";
        

        public string ButiksNavn { get; set; }
        public string Lokation { get; set; }

        public Dictionary<int, ButikItems> GetAllButikVarer()
        {
            // Varerne skal i en dictionary, og jsonreaderen returnere en liste, så hver vare i listen bliver addet til dictionary med id som key
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
            // Når man skal skrive en ny vare til json skal man skrive alle varerne igen, det skal også være en liste, så man tilføjer alle eksisterende varer og derefter den nye vare og så skriver man det i json filen.
            JsonVareWriter.WriteToJson(varer, filepath); 
        }

        public void DeleteItem(int id)
        {
            List<ButikItems> varer = new List<ButikItems>();
            foreach (var vare in GetAllButikVarer().Values)
            {
                if (vare.ID != id)
                {
                    varer.Add(vare);
                }
            }
            // Man skal bruge en liste til jsonwriteren, så man tilføjer alle vare undtagen den med det id man vil slette og så bruger man WriteToJson
            JsonVareWriter.WriteToJson(varer, filepath);

            
        }

        

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
        public List<ButikItems> FilterItems(string criteria) // Denne metode filtrerer kun ud fra en string på varernes navn
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
        public List<ButikItems> FilterButiks(string butik) // Denne metode filtrerer kun ud fra en string på butikkernes navn
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
        public List<ButikItems> FilterItemsAndButiks(string criteria, string butik) //Denne metode filtrerer ud fra både Butiknavn og varenavn
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
        public List<ButikItems> FilterByEitherItemOrButik(string criteria, string butik) //Denne metode bruger de to andre metoder alt efter om et søgefelt er tomt eller ej.
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
