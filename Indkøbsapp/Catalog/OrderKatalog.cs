using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        // Her er alle filstierne på json filerne, som vi bruger til at hente og lægge til filen.
        private string filepath = @"Data\JsonOrdrer.json";
        private string filepathProcess = @"Data\OrderInProcess.json";
        private string filepathCompleted = @"Data\CompletedOrdrer.json";

        public OrderKatalog()
        {
           
        }

        //bruges til at skabe en ny order i en Dicionary hvor brugerens username er key og laver loggedinuser til den aktive bruger
        public void CreateOrder(string username)
        {
            Dictionary<string, Ordrer> Katalog = GetAllOrdrer();
            if (!Katalog.ContainsKey(username))
            {
                Ordrer p = new Ordrer();
                p.Buyer = SharedMemory.LoggedInUser;
                Katalog.Add(username,p);
                JsonOrdrerKatalogFileWriter.WriteToJson(Katalog, filepath);
            }
        }

        // Finder order udfra brugerens username
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

        // Sletter orderen fra Dictionary filen
        public void DeleteOrder(string username)
        {
            Dictionary<string, Ordrer> Katalog = GetAllOrdrer();
            if (Katalog.ContainsKey(username))
            {
                Katalog.Remove(username);
                JsonOrdrerKatalogFileWriter.WriteToJson(Katalog, filepath);
            }
        }

        //Henter alle order i json filen
        public Dictionary<string, Ordrer> GetAllOrdrer()
        {
            return JsonOrdrerKatalogFileReader.ReadJson(filepath);
        }

        // Sætter en order en i en ny json fil der håndtere order der mangler leverandør.
        public void AddOrderToProcess(Ordrer order)
        {
            Dictionary<int, Ordrer> ed = GetAllOrdrerInProcess();
            order.ID = ed.Count;
            order.Buyer = SharedMemory.LoggedInUser;
            order.AntalVarerIOdrer = SharedMemory.ActiveOrdrer.AntalVarerIOdrer;
            ed.Add(order.ID, order);
            OrderInProcessWriter.WriteToJson(ed,filepathProcess);
        }

        //Fjerner orderen fra json process filen
        public void DeleteFromProcess(int id)
        {
            Dictionary<int, Ordrer> ed = GetAllOrdrerInProcess();
            if (ed.ContainsKey(id))
            {
                ed.Remove(id);
            }
            OrderInProcessWriter.WriteToJson(ed,filepathProcess);
        }

        //Henter alle order i process
        public Dictionary<int, Ordrer> GetAllOrdrerInProcess()
        {
            return OrderInProcessReader.ReadJson(filepathProcess);
        }

        // henter alle færdige gjorte ordrer.
        public Dictionary<int, CompletedOrder> GetAllCompletedOrders()
        {
            return JsonCompletedOrderReader.ReadJson(filepathCompleted);
     }


        // Tilføjer til færdige gjorte ordrer json filen og tilføjer leverandør og id.
        public void AddCompletedOrder(Bruger user,Ordrer order)
        {
            
            Dictionary<int, CompletedOrder> ed = GetAllCompletedOrders();
            Dictionary<int, Ordrer> ip = GetAllOrdrerInProcess();
            CompletedOrder cd = new CompletedOrder(order);
            cd.Leverandør = user;
            cd.Ordrer.ID = ed.Count;
            ed.Add(cd.Ordrer.ID,cd);
            
            JsonCompletedOrderWriter.WriteToJson(ed, filepathCompleted);


        }
    }
}
