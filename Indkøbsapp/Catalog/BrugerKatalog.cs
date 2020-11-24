using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Interfaces;
using Indkøbsapp.Models;

namespace Indkøbsapp.Catalog
{
    public class BrugerKatalog : IBrugerKatalog
    {
        private Dictionary<int,IBruger> users { get; }

        public BrugerKatalog()
        {
            users=new Dictionary<int, IBruger>();
        }

        public void AddUser()
        {
            throw new NotImplementedException();
        }

        public IBruger SearchUser(int id)
        {
            return users[id];
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
            users.Remove(id);
        }

        public List<IBruger> FilteredUsers(string criteria)
        {
            List<IBruger> emptyList = new List<IBruger>();
            string lcriteria = criteria.ToLower();

            foreach (IBruger user in users.Values)
            {
                string lName = user.Navn.ToLower();
                string lAdress = user.Adresse.ToLower();
                if (lName.Contains(lcriteria) || lAdress.Contains(lcriteria))
                {
                    emptyList.Add(user);
                }
            }
            return emptyList;
        }
    }
}
