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
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Indkøbsapp.Pages.Brugere
{
    public class BrugerIndexModel : PageModel
    {
        [BindProperty]
        public Bruger Bruger { get; set; }
        public IBrugerKatalog Users { get; }
        public IOrdrerKatalog Ordres { get; }

        public BrugerIndexModel(IBrugerKatalog users, IOrdrerKatalog ordres)
        {
            Users = users;
            Ordres = ordres;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {

            Bruger check = Users.CheckPassword(Bruger);
            if (check != null)
            {
                if ( Bruger is Admin)
                {
                    SharedMemory.LoggedInUser = check;
                }
                else
                {
                    SharedMemory.ActiveOrdrer = Ordres.FindOrder(check.UserName);
                    if (SharedMemory.ActiveOrdrer == null)
                    {
                        Ordres.CreateOrder(check.UserName);
                        SharedMemory.ActiveOrdrer = Ordres.FindOrder(check.UserName);
                    }
                   
                    SharedMemory.LoggedInUser = check;
                    return RedirectToPage("BrugerSide", "Bruger", new { username = check.UserName });
                }
        
            }
            return Page();
        }
    }
}


