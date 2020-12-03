using Indkøbsapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indkøbsapp.Interfaces
{
    public interface IRepositoryButik
    {
        
        List<Butik> GetAllButikker();
        void AddButik(Butik bk);
        void DeleteButik(Butik db);
    }
}
