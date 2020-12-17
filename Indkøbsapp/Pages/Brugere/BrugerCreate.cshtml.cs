using Indkøbsapp.Helpers;
using Indkøbsapp.Models;
using Indkøbsapp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Indkøbsapp.Pages.Brugere
{
    public class BrugerCreateModel : PageModel
    {
        //Porpertien vi bruger til at indeholde de værdier vi skriver ind på side
        [BindProperty]
        public Bruger Bruger { get; set; }

        //Dette er vores katalog af brugere
        public IBrugerKatalog Users { get; }


        //constructor sørger for vi har de nødvendige services på siden 
        public BrugerCreateModel(IBrugerKatalog users)
        {
            Users = users;
        }
        public void OnGet()
        {
        }


        //OnPost metode der bruges når vi på selve hjemmsiden skriver noget en ind i en form og trykker på selve post metoden
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
