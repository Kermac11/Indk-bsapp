using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Models;

namespace Indkøbsapp.Interfaces
{
   public interface IBrugerKatalog
    {
        void CreateUser();
        IBruger SearchUser();
        void UpdateUser();
        void DeleteUser();
        List<IBruger> FilteredUsers();
    }
}
