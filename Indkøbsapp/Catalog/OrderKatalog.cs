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
            Dictionary<string,Ordrer> Katalog = new Dictionary<string, Ordrer>();
            if (!Katalog.ContainsKey(username))
            {
                Katalog.Add(username, new Ordrer());
                SharedMemory.ActiveOrdrer = Katalog[username];
                JsonOrdrerKatalogFileWriter.WriteToJson(Katalog, filepath);
            }
        }

        public Ordrer FindOrder(string username)
        {
            Dictionary<string, Ordrer> Katalog = new Dictionary<string, Ordrer>();
            if (Katalog.ContainsKey(username))
            {
                return Katalog[username];
            }

            return null;

        }

        public void DeleteOrder(string username)
        {
            Dictionary<string, Ordrer> Katalog = new Dictionary<string, Ordrer>();
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
