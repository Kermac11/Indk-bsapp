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
        private Dictionary<int, Bruger> _users;
        public BrugerKatalog()
        {
            _users=new Dictionary<int, Bruger>();
        }

        public Dictionary<int, Bruger> Users
        {
            get { return _users; }
        }

        public void CreateUser(Bruger user)
        {
            int newUserId = _users.Count;

            if (!_users.ContainsKey(user.ID))
            {
                _users.Add(user.ID, user);
            }
            else
            {
                user.ID = newUserId + 1;
                _users.Add(user.ID, user);

            }
        }
        public IBruger SearchUser(int id)
        {
            if (_users.ContainsKey(id))
            {
                return _users[id];
            }

            return null;
        }

        public void UpdateUser(Bruger bruger)
        {
            if (bruger != null)
            {
                _users[bruger.ID].Adresse = bruger.Adresse;
                _users[bruger.ID].Navn = bruger.Navn;
            }
        }

        public void DeleteUser(int id)
        {
            if (_users.ContainsKey(id))
            {
                _users.Remove(id);
            }
        }

        public Dictionary<int, Bruger> FilteredUsers(string criteria)
        {
            Dictionary<int, Bruger> emptyList = new Dictionary<int, Bruger>();
            criteria = criteria.ToLower();
            foreach (Bruger user in _users.Values)
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
