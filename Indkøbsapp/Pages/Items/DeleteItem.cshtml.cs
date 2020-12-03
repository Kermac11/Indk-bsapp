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
        private IButiksKatalog repo;
        public DeleteItemModel(IButiksKatalog repository)
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
