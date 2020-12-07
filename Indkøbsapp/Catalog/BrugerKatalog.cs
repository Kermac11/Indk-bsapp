﻿using System;
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
        private string filepathAdmin = @"Data\AdminKatalog.json";

        public BrugerKatalog()
        {
        }


        public void CreateUser(Bruger user)
        {
            Dictionary<string, Bruger> _users = GetAllUsers();
            Dictionary<string, Admin> _admins = GetAllAdmins();
            int newUserId = _users.Count;
            if (!_admins.ContainsKey(user.UserName))
            {
                if (!_users.ContainsKey(user.UserName))
                {
                    user.ID = _users.Count + 1;
                    user.CreationDate = DateTime.Now;
                    _users.Add(user.UserName, user);
                }

                JsonFileWriter.WriteToJson(_users, filepath);
            }
        }

        public Bruger SearchUser(string username)
        {
            Dictionary<string, Bruger> _users = GetAllUsers();
            Dictionary<string, Admin> _admins = GetAllAdmins();
            if (_admins.ContainsKey(username))
            {
                return _admins[username];

            }
            if (_users.ContainsKey(username))
            {
                return _users[username];
            }

            return null;
        }

       public Bruger SearchUserId(int id)
        {
            foreach (Admin user in GetAllAdmins().Values)
            {
                if (user.ID == id)
                {
                    return user;
                }
            }
            foreach (Bruger user in GetAllUsers().Values)
            {
                if (user.ID == id)
                {
                    return user;
                }    
            }

            return null;
        }

        public void UpdateUser(Bruger bruger)
        {
            Dictionary<string, Bruger> _users = GetAllUsers();
            if (bruger != null)
            {
                _users[bruger.UserName] = bruger;
            }
            JsonFileWriter.WriteToJson(_users, filepath);
        }

        public void DeleteUserName(string username)
        {
            Dictionary<string, Bruger> _users = GetAllUsers();
            if (_users.ContainsKey(username))
            {
                _users.Remove(username);
            }
            JsonFileWriter.WriteToJson(_users,filepath);
        }

        public void DeleteUserId(int id)
        {
            Bruger brugerCheck = null;
            Dictionary<string, Bruger> _users = GetAllUsers();
            foreach (Bruger user in _users.Values)
            {
                if (user.ID == id)
                {
                    brugerCheck = user;
                }
            }

            if (brugerCheck != null)
            {
                _users.Remove(brugerCheck.UserName);
                JsonFileWriter.WriteToJson(_users,filepath);
            }
           
        }

        public void DeleteUser(string user)
        {
            Dictionary<string, Bruger> _users = GetAllUsers();
            if (_users.ContainsKey(user))
            {
                _users.Remove(user);
            }
            JsonFileWriter.WriteToJson(_users, filepath);
        }

        public Dictionary<string, Bruger> FilteredUsers(string criteria)
        {
            Dictionary<string, Bruger> _users = GetAllUsers();
            Dictionary<string, Bruger> emptyList = new Dictionary<string, Bruger>();
            criteria = criteria.ToLower();
            foreach (Bruger user in _users.Values)
            {
                if (user.Navn.ToLower().Contains(criteria) || user.Adresse.ToLower().Contains(criteria))
                {
                    emptyList.Add(user.UserName, user);
                }

            }

            return emptyList;
        }

        public Bruger CheckPassword(Bruger bruger)
        {
            Dictionary<string, Bruger> _users = GetAllUsers();
            Dictionary<string, Admin> _admins = GetAllAdmins();

            if (_admins.ContainsKey(bruger.UserName))
            {
                if (_admins[bruger.UserName].PassWord == bruger.PassWord)
                {
                    return _admins[bruger.UserName];
                }

            }
            if (_users.ContainsKey(bruger.UserName))
            {
                if (_users[bruger.UserName].PassWord == bruger.PassWord)
                {
                    return _users[bruger.UserName];
                }
                
            }
            return null;
        }

        public Dictionary<string, Bruger> SortByCreation()
        {
            Dictionary<string, Bruger> _users = GetAllUsers();
            foreach (KeyValuePair<string,Bruger> item in _users.OrderBy(key => key.Value.CreationDate))
            {
                _users.Add(item.Key,item.Value);
            }

            return _users;
        }

        public Dictionary<string, Bruger> GetAllUsers()
        {
            return JsonFileReader.ReadJson(filepath);
        }

        public Dictionary<string, Admin> GetAllAdmins()
        {
            return JsonAdminFileReader.ReadJson(filepathAdmin);
        }
    }
}
