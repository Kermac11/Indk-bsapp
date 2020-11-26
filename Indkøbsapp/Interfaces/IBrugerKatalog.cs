using System.Collections.Generic;
using Indkøbsapp.Models;

namespace Indkøbsapp.Interfaces
{
   public interface IBrugerKatalog
    {
        public Dictionary<int,IBruger> Users { get; set; }
        void CreateUser(IBruger user);
        IBruger SearchUser(int id);
        void UpdateUser(IBruger user);
        void DeleteUser(int id);
        Dictionary<int,IBruger> FilteredUsers(string criteria);
    }
}
