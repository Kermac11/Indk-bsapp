using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Interfaces;
using Indkøbsapp.Models;
using Indkøbsapp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Indkøbsapp.Pages.Items
{
    public class CreateButikItemModel : PageModel
    {
        private IButiksVareKatalog repo;
        
        [BindProperty]
        public ButikItems Item { get; set; }

        public List<string> ButikNavneList;
        public CreateButikItemModel(IButiksVareKatalog repository,IRepositoryButik butikNavne)
        {
            repo = repository;
            ButikNavneList=new List<string>(); // Her hentes alle butiknavnene til en dropdown menu så man kun kan vælge butikker der findes i systemet
            foreach (var butik in butikNavne.GetAllButikker())
            {
                if (!ButikNavneList.Contains(butik.ButiksNavn))
                {
                    ButikNavneList.Add(butik.ButiksNavn);
                }
            }
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        

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

