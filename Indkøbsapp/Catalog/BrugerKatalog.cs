using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Indkøbsapp.Interfaces;
using Indkøbsapp.Models;
using Indkøbsapp.Services;

namespace Indkøbsapp.Catalog
{
    public class BrugerKatalog : IBrugerKatalog
    {
        private Dictionary<int, IBruger> _users;

        public BrugerKatalog()
        {
            _users = new Dictionary<int, IBruger>();
        }


        public Dictionary<int, IBruger> Katalog
        {

            get { return _users; }
        }


        public void CreateUser(IBruger user)
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

        public void UpdateUser(IBruger bruger)
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

        public Dictionary<int, IBruger> FilteredUsers(string criteria)
        {
            Dictionary<int, IBruger> emptyList = new Dictionary<int, IBruger>();
            criteria = criteria.ToLower();
            foreach (IBruger user in _users.Values)
            {
                if (user.Navn.ToLower().Contains(criteria) || user.Adresse.ToLower().Contains(criteria))
                {
                    emptyList.Add(user.ID, user);
                }

            }

            return emptyList;
        }

        public IBruger CheckPassword(Bruger bruger)
        {
            foreach (IBruger user in _users.Values)
            {
                if (user.Navn == bruger.Navn && user.PassWord == bruger.PassWord)
                {
                    return user;

                }
            }

            return null;
        }
    }
}
