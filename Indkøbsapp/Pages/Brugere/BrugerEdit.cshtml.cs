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
        // Katalog der indeholder alle bruger
        public IBrugerKatalog Katalog { get; }
      
        // Bruges til at indeholde ændringer på brugeren 
        [BindProperty] 
        public Bruger Bruger { get; set; }

        //Klargører services
        public BrugerEditModel(IBrugerKatalog katalog)
        {
            Katalog = katalog;
        }

        // OnGet er den route vi bruger når vi kommer ind på siden
        public void OnGet(string bruger)
        {
            Bruger = Katalog.SearchUser(bruger);
        }

        // Når vi burger post formen på siden 
        public IActionResult OnPost()
        {
            Katalog.UpdateUser(Bruger);
            SharedMemory.LoggedInUser = Bruger;
            return RedirectToPage("BrugerSide", "Bruger", new { username = Bruger.UserName });
        }
    }
}
