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

        public IBruger SearchUser(int id)
        {
            if (Users.ContainsKey(id))
            {
                return Users[id];
            }

            return null;
        }

        public void UpdateUser(IBruger user)
        {
            if (Users.ContainsKey(user.ID))
            {
                Users[user.ID] = user;
            }   
        }

        public void DeleteUser(int id)
        {
            if (Users.ContainsKey(id))
            {
                Users.Remove(id);
            }
        }

        public Dictionary<int, IBruger> FilteredUsers(string criteria)
        {
            Dictionary<int,IBruger> el = new Dictionary<int, IBruger>();
            criteria = criteria.ToLower();
            foreach (IBruger user in Users.Values)
            {
                if (user.Navn.ToLower().Contains(criteria) || user.Adresse.ToLower().Contains(criteria))
                {
                    el.Add(user.ID,user);
                }
                
            }

            return el;
        }
    }
}
