using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Models;
using Indkøbsapp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Indkøbsapp.Pages.Brugere
{
    public class BrugerSideModel : PageModel
    {
        [BindProperty]
        public IBruger Bruger { get; set; }
        public IBrugerKatalog Users { get; }

        public BrugerSideModel(IBrugerKatalog list)
        {
            Users = list;
        }
        public void OnGet()
        {
        }

        public void OnGetBruger (string username)
        {
            Bruger = Users.SearchUser(username);
        }

    }
}
