using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Interfaces;
using Indkøbsapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Indkøbsapp.Pages.Items
{
    public class CreateButikItemModel : PageModel
    {
        private IButiksVareKatalog repo;

        [BindProperty]
        public ButikItems Item { get; set; }

        public CreateButikItemModel(IButiksVareKatalog repository)
        {
            repo = repository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        //Der skal være noget der håndterer at Id passer til item fordi den addes til en dictionary og ikke en list
        //Den tilføjer en vare med id=0 det kan man kun gøre en gang, det er lidt mærkeligt hvis man selv skal vælge et id
        //
        //Der skal være noget til at vælge et billede måske, ellers giver det ikke mening at have det

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            repo.AddItem(Item);
            return RedirectToPage("ButikItems");
        }

    }

}

