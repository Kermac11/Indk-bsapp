using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Interfaces;
using Indkøbsapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Indkøbsapp.Services;

namespace Indkøbsapp.Pages.Butikker
{
    public class CreateButikModel : PageModel
    {
        private IRepositoryButik fbp;

        [BindProperty]
        public Butik Butik { get; set; }

        public CreateButikModel(IRepositoryButik repository)
        {
            fbp = repository;
        }


        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            fbp.AddButik(Butik);
            return RedirectToPage("ButikIndex");
        }
    }
}
