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
        private IOrdrerKatalog _ordrers;
        private IBrugerKatalog _users;
        private IButiksVareKatalog _katalog;
        [BindProperty]
        public Ordrer Odrer { get; set; }
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

        public IActionResult OnPostDelete(int id)
        {
            SharedMemory.ActiveOrdrer.DeleteItem(id);
            return Page();
        }
        public IActionResult OnPostAdd(int id)
        {
            SharedMemory.ActiveOrdrer.AddItem(_katalog.FindItem(id));
            return Page();
        }
    }
}
