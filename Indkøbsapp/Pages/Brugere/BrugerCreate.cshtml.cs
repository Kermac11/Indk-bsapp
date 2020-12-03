using Indkøbsapp.Models;
using Indkøbsapp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Indkøbsapp.Pages.Brugere
{
    public class BrugerCreateModel : PageModel
    {
        [BindProperty]
        public Bruger Bruger { get; set; }

        public IBrugerKatalog Users { get; }

        public BrugerCreateModel(IBrugerKatalog users)
        {
            Users = users;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            Users.CreateUser(Bruger);

            return RedirectToPage("BrugerIndex");
        }
    }
}
