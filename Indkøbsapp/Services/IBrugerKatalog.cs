using System.Collections.Generic;
using Indkøbsapp.Models;

namespace Indkøbsapp.Services
{
   public interface IBrugerKatalog
    {
        void CreateUser(Bruger user);
        public string UserName { get; set; }
        Bruger SearchUser(string username);
        Bruger SearchUserId(int id);
        void UpdateUser(Bruger user);
        void DeleteUserName(string username);        
        void DeleteUserId(int id);
        Dictionary<string,Bruger> FilteredUsers(string criteria); 
        Bruger CheckPassword(Bruger bruger);
        Dictionary<string, Bruger> GetAllUsers();
    }
}
