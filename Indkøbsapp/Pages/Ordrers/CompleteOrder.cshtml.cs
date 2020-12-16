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
        private IBrugerKatalog _users;
        private IOrdrerKatalog _orders;
        public Ordrer Order { get; set; }
        public Bruger Bruger { get; set; }

        public CompleteOrderModel(IBrugerKatalog users, IOrdrerKatalog orders)
        {
            _users = users;
            _orders = orders;
            Bruger = SharedMemory.LoggedInUser;
        }
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
