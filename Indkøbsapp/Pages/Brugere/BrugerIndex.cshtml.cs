using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Indkøbsapp.Helpers;
using Indkøbsapp.Interfaces;
using Indkøbsapp.Models;
using Indkøbsapp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Session;

namespace Indkøbsapp.Pages.Brugere
{
    public class BrugerIndexModel : PageModel
    {
        [BindProperty]
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

            Bruger check = Users.CheckPassword(Bruger);
            if (check != null)
            {
                SharedMemory.LoggedInUser = check;
                return RedirectToPage("BrugerSide", "Bruger", new { username = check.UserName });
            }
            return Page();
        }
    }
}


