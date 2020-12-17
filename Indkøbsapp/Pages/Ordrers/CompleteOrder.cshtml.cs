using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Helpers;
using Indkøbsapp.Models;
using Indkøbsapp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Indkøbsapp.Pages.Ordrers
{
    public class CompleteOrderModel : PageModel
    {
        //Indeholder alle brugere
        private IBrugerKatalog _users;

        //Indeholder alle ordrer
        private IOrdrerKatalog _orders;

        // orderen der færdiggøres
        public Ordrer Order { get; set; }
        // brugeren der ligges til orderen
        public Bruger Bruger { get; set; }

        //Henter de nødvendige service for siden
        public CompleteOrderModel(IBrugerKatalog users, IOrdrerKatalog orders)
        {
            _users = users;
            _orders = orders;
            Bruger = SharedMemory.LoggedInUser;
        }

        //Putter orderen ind i orderinprocss json filen så den kan hentes til leverandører senere
        public void OnGet()
        {
            Order = _orders.FindOrder(Bruger.UserName);
            _orders.AddOrderToProcess(Order);
            _orders.DeleteOrder(Bruger.UserName);
            _orders.CreateOrder(Bruger.UserName);
            SharedMemory.ActiveOrdrer = _orders.FindOrder(Bruger.UserName);
        }
    }
}
