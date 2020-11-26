using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Interfaces;
using Indkøbsapp.Models;
using Indkøbsapp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Indkøbsapp.Pages.Brugere
{
    public class BrugerIndexModel : PageModel
    { [BindProperty] 
        public Bruger Bruger { get; set; }
        public IBrugerKatalog Users { get; }

        public BrugerIndexModel(IBrugerKatalog users)
        {
            Users = users;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            foreach (IBruger user in Users.Users.Values)
            {
                if (user.Navn == Bruger.Navn && user.PassWord == Bruger.PassWord)
                {
                    return RedirectToPage("BrugerSide","Bruger", new {id = user.ID});
                }
            }

            return Page();
        }
    }
}


