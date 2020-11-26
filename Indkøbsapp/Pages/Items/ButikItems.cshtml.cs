using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using Indkøbsapp.Catalog;
using Indkøbsapp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Indkøbsapp.Pages
{
    public class ButikItemsModel : PageModel
    {
        public IButiksKatalog repo;
        public List<IButikItems> Items { get; set; }

        [BindProperty] public string Criteria { get; set; }

        public ButikItemsModel()
        {
            repo = new ButiksKatalog();
            Items=new List<IButikItems>();
            foreach (var item in repo.GetAllButikItems().Values)
            {
                Items.Add(item);
            }
        }




        public void OnGet()
        {

        }
    }
}