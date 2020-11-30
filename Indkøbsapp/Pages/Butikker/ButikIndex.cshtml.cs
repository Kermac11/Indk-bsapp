using System.Collections.Generic;
using Indkøbsapp.Models;
using Indkøbsapp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Indkøbsapp.Pages.Butikker
{
    public class ButikIndexModel : PageModel
    {
        public FakeButikRepository repo { get; }

        public ButikIndexModel(FakeButikRepository repository)
        {
            repo = repository;
        }

        public List<Butik> Butikker { get; private set; }

        public IActionResult OnGet()
        {
            Butikker = repo.GetAllButikker();
            return Page();
        }
    }
}

