using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using Indkøbsapp.Catalog;
using Indkøbsapp.Helpers;
using Indkøbsapp.Interfaces;
using Indkøbsapp.Models;
using Indkøbsapp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Indkøbsapp.Pages
{
    public class ButikItemsModel : PageModel
    {
        public IButiksVareKatalog repo;

        public IOrdrerKatalog _orderrepo;
        public List<ButikItems> Items { get; set; }

        [BindProperty] public string Criteria { get; set; }

        public ButikItemsModel(IButiksVareKatalog varer, IOrdrerKatalog orderrepo)
        {
            repo = varer;
            _orderrepo = orderrepo;
        }
        public void OnGet()
        {
            Items = repo.FilterItems(Criteria);
        }

        public void OnPost()
        {
            Items = repo.FilterItems(Criteria);
        }

        public void OnPostAdd(int id)
        {
            if (SharedMemory.LoggedInUser == null)
            {
                SharedMemory.LoggedInUser = new Bruger();
                SharedMemory.LoggedInUser.UserName = "Guest";
                SharedMemory.LoggedInUser.Navn = "Guest";
                _orderrepo.CreateOrder(SharedMemory.LoggedInUser.UserName);
                SharedMemory.ActiveOrdrer = _orderrepo.FindOrder(SharedMemory.LoggedInUser.UserName);
                SharedMemory.ActiveOrdrer.AddItem(repo.FindItem(id));

            }
            else
            {
                SharedMemory.ActiveOrdrer.AddItem(repo.FindItem(id));
            }
            
        }
    }
}