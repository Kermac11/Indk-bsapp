using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Indkøbsapp.Interfaces;
using Indkøbsapp.Models;
using Indkøbsapp.Services;
using RazorPagesEventMaker.Helpers;

namespace Indkøbsapp.Catalog
{
    public class BrugerKatalog : IBrugerKatalog
    {
        private string filepath = @"Data\BrugerKatalog.json";

        public BrugerKatalog()
        {
        }


        public void CreateUser(Bruger user)
        {
            Dictionary<int, Bruger> _users = GetAllUsers();
            int newUserId = _users.Count;
            if (!_users.ContainsKey(user.ID))
            {
                _users.Add(user.ID, user);
            }
            else
            {
                user.ID = newUserId;
                _users.Add(user.ID, user);
            }

            JsonFileWriter.WriteToJson(_users, filepath);
        }

        public IBruger SearchUser(int id)
        {
            Dictionary<int, Bruger> _users = GetAllUsers();
            if (_users.ContainsKey(id))
            {
                return _users[id];
            }

            return null;
        }

        public void UpdateUser(Bruger bruger)
        {
            Dictionary<int, Bruger> _users = GetAllUsers();
            if (bruger != null)
            {
                _users[bruger.ID].Adresse = bruger.Adresse;
                _users[bruger.ID].Navn = bruger.Navn;
            }
            JsonFileWriter.WriteToJson(_users, filepath);
        }

        public void DeleteUser(int id)
        {
            Dictionary<int, Bruger> _users = GetAllUsers();
            if (_users.ContainsKey(id))
            {
                _users.Remove(id);
            }
            JsonFileWriter.WriteToJson(_users, filepath);
        }

        public Dictionary<int, Bruger> FilteredUsers(string criteria)
        {
            Dictionary<int, Bruger> _users = GetAllUsers();
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

        public Bruger CheckPassword(Bruger bruger)
        {
            Dictionary<int, Bruger> _users = GetAllUsers();
            foreach (Bruger user in _users.Values)
            {
                if (user.Navn == bruger.Navn && user.PassWord == bruger.PassWord)
                {
                    return user;

                }
            }

            return null;
        }

        public Dictionary<int, Bruger> GetAllUsers()
        {
             return JsonFileReader.ReadJson(filepath);
        }
    }
}
