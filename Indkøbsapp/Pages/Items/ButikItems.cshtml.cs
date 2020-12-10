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
        [BindProperty] public string ButikFilter { get; set; }
        [BindProperty] public string Criteria { get; set; }
        public List<string> ButikNavneList;

        public ButikItemsModel(IButiksVareKatalog varer, IRepositoryButik butikNavne)
        {
            repo = varer;
            ButikNavneList = new List<string>();
            foreach (var butik in butikNavne.GetAllButikker())
            {
                if (!ButikNavneList.Contains(butik.ButiksNavn))
                {
                    ButikNavneList.Add(butik.ButiksNavn);
                }
            }
        }


        //Admin knappperne skal gemmes hvis man ikke er admin
        //Mere filtrering
        //Man skal kunne se varetypen
        // filtrere ud fra varetypen med dropdown så kun varer af den type vises?
        //TILFØJ RIGTIGE VARER MED BILLEDER
        //Filtrering efter butikker



        public void OnGet(string butikNavn)
        {
            if (butikNavn != null)
            {
                ButikFilter = butikNavn;
            }
            Items = repo.FilterByEitherItemOrButik(Criteria, ButikFilter);
        }

        public void OnPostFilter()
        {
            Items = repo.FilterByEitherItemOrButik(Criteria, ButikFilter);
        }

        public void OnPostAdd(int id)
        {
            SharedMemory.ActiveOrdrer.AddItem(repo.FindItem(id));
        }
    }
}