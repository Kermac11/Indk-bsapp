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

        //Her ligger stivejen til json filerne der indholder admins og brugere, de bliver brugt til at hente og opdatere json filen-
        private string filepath = @"Data\BrugerKatalog.json";
        private string filepathAdmin = @"Data\AdminKatalog.json";

        //Constructor
        public BrugerKatalog()
        {
        }

        // denne methode checker først om der allerede eksitere en bruger med samme username får at undgå at programmet crasher.
        //derefter ligger den den nye Dictionary ind i json filen der indeholder brugerne.
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

        //Finder i json filen den korrkete bruger ved at bruge deres username som key, og derefter returnere valuen.
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

        //Samme som den forrige men bruger id istedet for username.
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

       // Opdatere brugeren i Dictionary ved at finde brugeren med det korrekte username, og opdatere json filen med det nye information.
        public void UpdateUser(Bruger bruger)
        {
            Dictionary<string, Bruger> _users = GetAllUsers();
            if (bruger != null)
            {
                _users[bruger.UserName] = bruger;
            }
            JsonFileWriter.WriteToJson(_users, filepath);
        }

        // Fjerner brugeren med det korrekte username, og derefter opdatere json filen.
        public void DeleteUserName(string username)
        {
            Dictionary<string, Bruger> _users = GetAllUsers();
            if (_users.ContainsKey(username))
            {
                _users.Remove(username);
            }
            JsonFileWriter.WriteToJson(_users,filepath);
        }

        // Samme som deleteusername men med id, dog bruger den en null bruger for at checke for brugeren ekistere, da man ikke kan bruge foreach og remove uden metoden crasher. Kan også lave det som en for loop, efter behov.
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

        //Aflevere tilbage filtred Dictionary efter navn eller adresse
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

        //Sammeligner username og paswword properties på brugerne i json filen, og derefter brugeren der opfylder kriterierne
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

        //Laver en Dictionary der sortere efter dato de er skabt
        public Dictionary<string, Bruger> SortByCreation()
        {
            Dictionary<string, Bruger> _users = GetAllUsers();
            foreach (KeyValuePair<string,Bruger> item in _users.OrderBy(key => key.Value.CreationDate))
            {
                _users.Add(item.Key,item.Value);
            }

            return _users;
        }

        // for fat i alle bruger i json filen for bruger
        public Dictionary<string, Bruger> GetAllUsers()
        {
            return JsonFileReader.ReadJson(filepath);
        }

        // for fat i alle admins i admin json filen
        public Dictionary<string, Admin> GetAllAdmins()
        {
            return JsonAdminFileReader.ReadJson(filepathAdmin);
        }
    }
}
