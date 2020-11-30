﻿using System.Collections.Generic;
using System.Linq;
using Indkøbsapp.Interfaces;
using Indkøbsapp.Models;
using RazorPagesEventMakerIC.Helpers;

namespace Indkøbsapp.Services
{
    public class ButiksKatalog : IButiksKatalog
    {
        private string filepath = @"Data\JsonVarer.json";
        
        public string ButiksNavn { get; set; }
        public string Lokation { get; set; }

        public Dictionary<int, ButikItems> GetAllButikVarer()
        {
            Dictionary<int,ButikItems> result= new Dictionary<int, ButikItems>();
            foreach (var vare in JsonVareReader.ReadJson(filepath))
            {
                result.Add(vare.ID,vare);
            }
            return result;
        }
        public IButikItems FindItem(int id)
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
            
            JsonVareWriter.WriteToJson(varer,filepath);
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
                foreach (var item in varer)
                {
                    if (item.ID == id)
                    {
                        varer.Remove(item);
                    }
                }
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

        public List<IButikItems> FilterItems(string criteria)
        {
            List<IButikItems> dl = new List<IButikItems>();
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
                foreach (IButikItems item in GetAllButikVarer().Values)
                {
                    if (item.Navn.ToLower().StartsWith(cl))
                    {
                        dl.Add(item);
                    }
                }
            }
            return dl;
        }
        public void EditVare(IButikItems vare)
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
                    }
                    varer.Add(va);
                }
                JsonVareWriter.WriteToJson(varer, filepath);
            }
        }
    }
}
