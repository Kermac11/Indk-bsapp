using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indkøbsapp.Interfaces
{
    interface IOrdrerKatalog
    {
        public List<IOrdrer> Katalog { get; set; }
        public void CreateOrder();
        public IOrdrer FindOrder(int id);
        public void DeleteOrder();
    }
}
