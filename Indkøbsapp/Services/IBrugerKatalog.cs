using System.Collections.Generic;
using Indkøbsapp.Models;

namespace Indkøbsapp.Services
{
   public interface IBrugerKatalog
    {
        public Dictionary<int,Bruger> Users { get;}
        void CreateUser(Bruger user);
        IBruger SearchUser(int id);
        void UpdateUser(Bruger user);
        void DeleteUser(int id);
        Dictionary<int,Bruger> FilteredUsers(string criteria);
    }
}
