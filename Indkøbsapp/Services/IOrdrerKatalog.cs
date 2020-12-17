using System.Collections.Generic;
using Indkøbsapp.Interfaces;
using Indkøbsapp.Models;

namespace Indkøbsapp.Services
{
    public interface IOrdrerKatalog
    {
        public void CreateOrder(string username);
        public Ordrer FindOrder(string username);
        public void DeleteOrder(string username);
        Dictionary<string, Ordrer> GetAllOrdrer();
        public void AddOrderToProcess(Ordrer order);
        public void DeleteFromProcess(int id);
        public Dictionary<int, Ordrer> GetAllOrdrerInProcess();
        public Dictionary<int, CompletedOrder> GetAllCompletedOrders();
        public void AddCompletedOrder(Bruger user,Ordrer order);
    }
}
