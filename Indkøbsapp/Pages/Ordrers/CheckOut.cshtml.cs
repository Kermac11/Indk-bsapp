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
        //Indeholder alle ordrer
        private IOrdrerKatalog _orderRepo;
        //Indeholder alle bruger
        private IBrugerKatalog _brugerRepo;
        //INdeholder vædierne orderen der skal vises på siden
        public Ordrer Order { get; set; }

        // Henter nødvendige services
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
