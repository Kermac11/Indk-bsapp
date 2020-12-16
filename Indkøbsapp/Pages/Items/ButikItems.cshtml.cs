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
        [BindProperty] public string ButikFilter { get; set; } // Dropdown menuen ændrer ButikFilter som bruges til at filtrere efter butik
        [BindProperty] public string Criteria { get; set; } // Søgefeltet ændrer Criteria som bruges til at filtrere efter varenavn
        public List<string> ButikNavneList;

        public ButikItemsModel(IButiksVareKatalog varer, IRepositoryButik butikNavne)
        {
            repo = varer; // repo sættes til at være hele varekataloget
            ButikNavneList = new List<string>(); // Der hentes en liste af alle butikkerne som bruges til dropdown menuen.
            foreach (var butik in butikNavne.GetAllButikker())
            {
                if (!ButikNavneList.Contains(butik.ButiksNavn))
                {
                    ButikNavneList.Add(butik.ButiksNavn);
                }
            }
        }

        //TILFØJ RIGTIGE VARER MED BILLEDER


        public void OnGet(string butikNavn)
        {
            if (butikNavn != null) // Hvis man bliver redirected en route-butikNavn vil varerne være filtreret efter den butik når man kommer til siden med varer
            {
                ButikFilter = butikNavn;
            }
            Items = repo.FilterByEitherItemOrButik(Criteria, ButikFilter); //Filtreringsmetoden bruger både Criteria og ButikFilter til at vise det man søger efter
        }
        public void OnGet()
        {
            Items = repo.FilterItems(Criteria);
        }

        public void OnPostFilter()
        {
            Items = repo.FilterByEitherItemOrButik(Criteria, ButikFilter);
        }

        // Sørger for at varene bliver lagt ind i den rigtige ordrer
        public void OnPostAdd(int id)
        {
            SharedMemory.ActiveOrdrer.AddItem(repo.FindItem(id)); //Når man lægger en vare i kurven kommer den i ActiveOrder som er static
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