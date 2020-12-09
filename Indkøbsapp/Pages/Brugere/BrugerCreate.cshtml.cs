using Indkøbsapp.Helpers;
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            int checkInt = Users.GetAllUsers().Count;
            Users.CreateUser(Bruger);
            SharedMemory.LoggedInUser = Bruger;

            if (Users.GetAllUsers().Count > checkInt)
            {
                return RedirectToPage("BrugerIndex");
            }
            else
            {
                return Page();
            }
        }
    }
}
