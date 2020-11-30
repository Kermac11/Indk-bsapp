using System.Collections.Generic;
using Indkøbsapp.Interfaces;
using Indkøbsapp.Models;

namespace Indkøbsapp.Services
{
    public interface IOrdrerKatalog
    {
        public Dictionary<int,Ordrer> Katalog { get; set; }
        public void CreateOrder(Ordrer order);
        public Ordrer FindOrder(int id);
        public void DeleteOrder(int id);
        public List<Ordrer> FindBrugereOrder(Bruger user);
    }
}
