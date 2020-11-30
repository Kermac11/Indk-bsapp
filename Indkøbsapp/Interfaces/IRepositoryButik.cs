using Indkøbsapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indkøbsapp.Interfaces
{
    interface IRepositoryButik
    {
        
        public string ButiksNavn { get; set; }
        public string Lokation { get; set; }
        List<Butik> GetAllButikker();
        void AddButik(Butik bk);
    }
}
