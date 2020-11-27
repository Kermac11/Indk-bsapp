using System.Collections.Generic;
using Indkøbsapp.Models;

namespace Indkøbsapp.Services
{
   public interface IBrugerKatalog
    {
        void CreateUser(IBruger user);
        IBruger SearchUser(int id);
        void UpdateUser(IBruger user);
        void DeleteUser(int id);
        Dictionary<int,IBruger> FilteredUsers(string criteria);
        IBruger CheckPassword(Bruger bruger);
    }
}
