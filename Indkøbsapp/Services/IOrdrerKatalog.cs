using System.Collections.Generic;
using Indkøbsapp.Interfaces;
using Indkøbsapp.Models;

namespace Indkøbsapp.Services
{
    public interface IOrdrerKatalog
    {
        public void CreateOrder(string username);
        public Ordrer FindOrder(string username);
        public void DeleteOrder(string username);
    }
}
