using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Interfaces;
using Indkøbsapp.Models;

namespace Indkøbsapp.Services
{
    public class BrugereKatalog : IBrugerKatalog
    {
        public BrugereKatalog()
        {
            Users = new Dictionary<int, IBruger>();
        }
        public Dictionary<int, IBruger> Users { get; set; }
        public void CreateUser(IBruger user)
        {
            if (!Users.ContainsKey(user.ID))
            {
                Users.Add(user.ID, user);
            }
        }

        public IBruger SearchUser()
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(IBruger user)
        {
            
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, IBruger> FilteredUsers()
        {
            throw new NotImplementedException();
        }
    }
}
