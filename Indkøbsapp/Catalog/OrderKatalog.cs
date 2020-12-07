using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Helpers;
using Indkøbsapp.Interfaces;
using Indkøbsapp.Models;
using Indkøbsapp.Services;
using RazorPagesEventMaker.Helpers;

namespace Indkøbsapp.Catalog
{
    public class OrderKatalog : IOrdrerKatalog
    {
        private string filepath = @"Data\JsonOrdrer.json";

        public OrderKatalog()
        {
           
        }


        public void CreateOrder(string username)
        {
            Dictionary<string, Ordrer> Katalog = GetAllOrdrer();
            if (!Katalog.ContainsKey(username))
            {
                Ordrer p = new Ordrer();
                Katalog.Add(username,p);
                JsonOrdrerKatalogFileWriter.WriteToJson(Katalog, filepath);
            }
        }

        public Ordrer FindOrder(string username)
        {
            Dictionary<string, Ordrer> Katalog = GetAllOrdrer();
            if (Katalog.ContainsKey(username))
            {
                return Katalog[username];
            }
            else
            {
                CreateOrder(username);
            }

            return null;

        }

        public void DeleteOrder(string username)
        {
            Dictionary<string, Ordrer> Katalog = GetAllOrdrer();
            if (Katalog.ContainsKey(username))
            {
                Katalog.Remove(username);
                JsonOrdrerKatalogFileWriter.WriteToJson(Katalog, filepath);
            }
        }

        public Dictionary<string, Ordrer> GetAllOrdrer()
        {
            return JsonOrdrerKatalogFileReader.ReadJson(filepath);
        }
    }
}
