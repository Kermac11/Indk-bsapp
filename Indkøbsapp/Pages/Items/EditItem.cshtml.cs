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
    public class EditItemModel : PageModel
    {
        private IButiksKatalog repo;

        [BindProperty]
        public ButikItems Item { get; set; }

        public EditItemModel(IButiksKatalog repository)
        {
            repo = repository;
        }

        public IActionResult OnGet(int id)
        {
            Item=repo.GetAllButikVarer()[id];
            return Page();
        }
        //
        //Der skal være noget til at vælge et billede måske, ellers giver det ikke mening at have det

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                
                return Page();
            }

            repo.EditVare(Item);
            return RedirectToPage("ButikItems");
        }

    }

}
