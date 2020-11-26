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
    public class BrugereIndexModel : PageModel
    {
        public IBruger Bruger { get; set; }

        public IBrugerKatalog Users { get;}

        public BrugereIndexModel(IBrugerKatalog users)
        {
            Users = users;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (Users.Users.ContainsValue(Bruger))
            {
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
