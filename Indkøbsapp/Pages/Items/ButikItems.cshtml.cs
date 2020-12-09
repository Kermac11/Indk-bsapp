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


        //Admin knappperne skal gemmes hvis man ikke er admin
        //Mere filtrering
        //Man skal kunne se varetypen
        // filtrere ud fra varetypen med dropdown så kun varer af den type vises?
        //TILFØJ RIGTIGE VARER MED BILLEDER
        //Filtrering efter butikker



        public void OnGet()
        {
            Items = repo.FilterItems(Criteria);
        }

        public void OnPostFilter()
        {
            Items = repo.FilterItems(Criteria);
        }

        public void OnPostAdd(int id)
        {
            SharedMemory.ActiveOrdrer.AddItem(repo.FindItem(id));
        }
    }
}