using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Models;
using Indkøbsapp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Indkøbsapp.Pages.Ordrers
{

    public class CheckOutModel : PageModel
    {
        private IOrdrerKatalog _orderRepo;

        private IBrugerKatalog _brugerRepo;
        public Ordrer Order { get; set; }

        public CheckOutModel(IOrdrerKatalog orderRepo, IBrugerKatalog brugerRepo)
        {
            _brugerRepo = brugerRepo;
            _orderRepo = orderRepo;
        }


        public void OnGet(string username)
        {

        }
    }
}
