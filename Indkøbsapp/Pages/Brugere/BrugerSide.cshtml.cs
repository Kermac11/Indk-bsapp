using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Models;
using Indkøbsapp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;

namespace Indkøbsapp.Pages.Brugere
{
    public class BrugerSideModel : PageModel
    {
        //Selve brugen vi er inde på
        [BindProperty]
        public Bruger Bruger { get; set; }
        //Indeholder alle bruger
        public IBrugerKatalog Users { get; }
        // Indeholder Ordrer 
        public IOrdrerKatalog Ordres { get;}

        //Henter nødvendige services
        public BrugerSideModel(IBrugerKatalog list, IOrdrerKatalog ordres)
        {
            Users = list;
            Ordres = ordres;
        }
        public void OnGet()
        {
         
        }

        //OnGet metode der bruges til at modtage login navnet så vi kan finde den korrekte bruger
        public void OnGetBruger (string username)
        {
            Bruger = Users.SearchUser(username);
        }
        

        //OnPost metode for admins til at slette bruger
        public void OnPostDelete(string deleteuser, string currentuser)
        {
            Users.DeleteUserName(deleteuser);
            OnGetBruger(currentuser);

        }

        //OnPost metode for leverandører at melde dem til at tage en order
        public void OnPostTakeorder(int id, string currentuser)
        {
            Ordres.AddCompletedOrder(Users.SearchUser(currentuser),Ordres.GetAllOrdrerInProcess()[id]);
            Ordres.DeleteFromProcess(id);
            OnGetBruger(currentuser);
        }
    }
}
