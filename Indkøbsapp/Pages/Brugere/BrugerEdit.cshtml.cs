using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Catalog;
using Indkøbsapp.Helpers;
using Indkøbsapp.Models;
using Indkøbsapp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Indkøbsapp.Pages.Brugere
{
    public class BrugerEditModel : PageModel
    {
        public IBrugerKatalog Katalog { get; }
      
        [BindProperty] 
        public Bruger Bruger { get; set; }

        public BrugerEditModel(IBrugerKatalog katalog)
        {
            Katalog = katalog;
        }

        public void OnGet(string bruger)
        {
            Bruger = Katalog.SearchUser(bruger);
        }

        public IActionResult OnPost()
        {
            Katalog.UpdateUser(Bruger);
            SharedMemory.LoggedInUser = Bruger;
            return RedirectToPage("BrugerSide", "Bruger", new { username = Bruger.UserName });
        }
    }
}
