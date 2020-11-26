using System.Collections.Generic;
using Indkøbsapp.Models;

namespace Indkøbsapp.Interfaces
{
   public interface IBrugerKatalog
    {
        public Dictionary<int,IBruger> Users { get; set; }
        void CreateUser(IBruger );
        IBruger SearchUser();
        void UpdateUser();
        void DeleteUser();
        Dictionary<int,IBruger> FilteredUsers();
    }
}
