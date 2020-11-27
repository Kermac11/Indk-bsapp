using System.Collections.Generic;
using Indkøbsapp.Models;

namespace Indkøbsapp.Services
{
   public interface IBrugerKatalog
    {
        void CreateUser(Bruger user);
        IBruger SearchUser(int id);
        void UpdateUser(Bruger user);
        void DeleteUser(int id);
        Dictionary<int,Bruger> FilteredUsers(string criteria);
        IBruger CheckPassword(Bruger bruger);
        Dictionary<int, Bruger> GetAllUsers();
    }
}
