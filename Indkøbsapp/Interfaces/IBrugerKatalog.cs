using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Models;

namespace Indkøbsapp.Interfaces
{
    public interface IBrugerKatalog
    {
        void AddUser();
        IBruger SearchUser(int id);
        void UpdateUser(IBruger bruger);
        void DeleteUser(int id);
        List<IBruger> FilteredUsers(string criteria);
    }
}