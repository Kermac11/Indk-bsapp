using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Indkøbsapp.Pages.Items
{
    public class DeleteItemModel : PageModel
    {

        // Dette er ikke en rigtig side man bliver routet til den og så sletter OnGet metoden den vare man har klikket på, og så bliver man sendt tilbage til varesiden

        private IButiksVareKatalog repo;
        public DeleteItemModel(IButiksVareKatalog repository)
        {
            repo = repository;
        }
        public IActionResult OnGet(int id)
        {
            repo.DeleteItem(id);
            return RedirectToPage("ButikItems");
        }
    }
}
