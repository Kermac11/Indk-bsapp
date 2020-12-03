using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using Indkøbsapp.Catalog;
using Indkøbsapp.Interfaces;
using Indkøbsapp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Indkøbsapp.Pages
{
    public class ButikItemsModel : PageModel
    {
        public IButiksKatalog repo;
        public List<IButikItems> Items { get; set; }

        [BindProperty] public string Criteria { get; set; }

        public ButikItemsModel(IButiksKatalog varer)
        {
            repo = varer;
        }
        //[required] og sådan noget
        public void OnGet()
        {
            Items = repo.FilterItems(Criteria);
        }

        public void OnPost()
        {
            Items = repo.FilterItems(Criteria);
        }
    }
}