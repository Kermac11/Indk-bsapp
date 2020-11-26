using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Interfaces;
using Indkøbsapp.Models;
using Indkøbsapp.Services;

namespace Indkøbsapp.Catalog
{
    public class BrugerKatalog : IBrugerKatalog
    {
        private Dictionary<int,IBruger> users { get; }

        public BrugerKatalog()
        {
            users=new Dictionary<int, IBruger>();
        }

        public Dictionary<int, IBruger> Users { get; set; }

        public void CreateUser(IBruger user)
        {
            int newUserId = Users.Count;

            if (!Users.ContainsKey(user.ID))
            {
                Users.Add(user.ID, user);
            }
            else
            {
                user.ID = newUserId + 1;
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

        public void UpdateUser(IBruger bruger)
        {
            if (bruger != null)
            {
                users[bruger.ID].Adresse = bruger.Adresse;
                users[bruger.ID].Navn = bruger.Navn;
            }
        }

        public void DeleteUser(int id)
        {
            if (Users.ContainsKey(id))
            {
                Users.Remove(id);
            }
        }

        public Dictionary<int,IBruger> FilteredUsers(string criteria)
        {
            Dictionary<int, IBruger> emptyList = new Dictionary<int, IBruger>();
            criteria = criteria.ToLower();
            foreach (IBruger user in Users.Values)
            {
                if (user.Navn.ToLower().Contains(criteria) || user.Adresse.ToLower().Contains(criteria))
                {
                    emptyList.Add(user.ID, user);
                }

            }

            return emptyList;
        }
    }
}
