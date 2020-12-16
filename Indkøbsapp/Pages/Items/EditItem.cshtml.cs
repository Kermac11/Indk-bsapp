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
        private IButiksVareKatalog repo;

        [BindProperty]
        public ButikItems Item { get; set; }
        public List<string> ButikNavneList;
        public EditItemModel(IButiksVareKatalog repository, IRepositoryButik butikNavne)
        {
            repo = repository;
            ButikNavneList = new List<string>();
            foreach (var butik in butikNavne.GetAllButikker())
            {
                if (!ButikNavneList.Contains(butik.ButiksNavn))
                {
                    ButikNavneList.Add(butik.ButiksNavn);
                }
            }
        }

        public IActionResult OnGet(int id)
        {
            Item=repo.GetAllButikVarer()[id];
            return Page();
        }
        

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
