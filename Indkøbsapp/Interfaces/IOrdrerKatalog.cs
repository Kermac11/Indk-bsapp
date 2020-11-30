using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Models;

namespace Indkøbsapp.Interfaces
{
    public interface IOrdrerKatalog
    {
        public IDictionary<int,IOrdrer> Katalog { get; set; }
        public void CreateOrder(IOrdrer order);
        public IOrdrer FindOrder(int id);
        public void DeleteOrder(int id);
        public List<IOrdrer> FindBrugereOrder(IBruger user);
    }
}
