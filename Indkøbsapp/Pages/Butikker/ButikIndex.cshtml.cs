using System.Collections.Generic;
using Indkøbsapp.Interfaces;
using Indkøbsapp.Models;
using Indkøbsapp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Indkøbsapp.Pages.Butikker
{
    public class ButikIndexModel : PageModel
    {
        public IRepositoryButik repo { get; }

        public ButikIndexModel(IRepositoryButik repository)
        {
            repo = repository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost(string butiksNavn)
        {
            repo.DeleteButik(butiksNavn);
            return Page();
        }
    }
}

