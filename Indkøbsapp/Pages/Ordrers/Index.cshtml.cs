using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Helpers;
using Indkøbsapp.Interfaces;
using Indkøbsapp.Models;
using Indkøbsapp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Indkøbsapp.Pages.Ordrers
{
    public class IndexModel : PageModel
    {

        // Indeholder alle ordrer
        private IOrdrerKatalog _ordrers;
        // Indeholder alle brugere
        private IBrugerKatalog _users;

        //Indeholder alle butivare
        private IButiksVareKatalog _katalog;
        [BindProperty]
        //Orderen der skal vises på siden
        public Ordrer Odrer { get; set; }
        //Henter nødvendige services
        public IndexModel(IOrdrerKatalog ordrer, IBrugerKatalog users, IButiksVareKatalog butiksKatalog)
        {
            _ordrers = ordrer;
            _users = users;
            _katalog = butiksKatalog;
            Odrer = SharedMemory.ActiveOrdrer;
        }
        public void OnGet()
        {
        }

        //Bruges til at kunne slette en vare fra kurven
        public IActionResult OnPostDelete(int id)
        {
            SharedMemory.ActiveOrdrer.DeleteItem(id);
            return Page();
        }

        //Bruges til at ligge samme vare ind i orderen
        public IActionResult OnPostAdd(int id)
        {
            SharedMemory.ActiveOrdrer.AddItem(_katalog.FindItem(id));
            return Page();
        }
    }
}
