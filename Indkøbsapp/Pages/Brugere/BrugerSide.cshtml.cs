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
        [BindProperty]
        public Bruger Bruger { get; set; }
        public IBrugerKatalog Users { get; }
        public IOrdrerKatalog Ordres { get;}

        public BrugerSideModel(IBrugerKatalog list, IOrdrerKatalog ordres)
        {
            Users = list;
            Ordres = ordres;
        }
        public void OnGet()
        {
         
        }

        public void OnGetBruger (string username)
        {
            Bruger = Users.SearchUser(username);
        }
        
        public void OnPostDelete(string deleteuser, string currentuser)
        {
            Users.DeleteUserName(deleteuser);
            OnGetBruger(currentuser);

        }
        public void OnPostTakeorder(int id, string currentuser)
        {
            Ordres.AddCompletedOrder(Users.SearchUser(currentuser),Ordres.GetAllOrdrerInProcess()[id]);
            Ordres.DeleteFromProcess(id);
            OnGetBruger(currentuser);
        }
    }
}
