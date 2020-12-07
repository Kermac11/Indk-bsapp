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
        public List<ButikItems> Items { get; set; }

        [BindProperty] public string Criteria { get; set; }

        public ButikItemsModel(IButiksVareKatalog varer)
        {
            repo = varer;
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
            SharedMemory.ActiveOrdrer.AddItem(repo.FindItem(id));
        }
    }
}