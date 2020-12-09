﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Interfaces;

namespace Indkøbsapp.Models
{
    public class OrderItem : ButikItems
    {
        public OrderItem(IButikItems item)
        {
            this.Price = item.Price;
            this.Billede = item.Billede;
            this.Description = item.Description;
            this.Navn = item.Navn;
            this.TypeVare = item.TypeVare;
            this.ID = item.ID;
        }
        public int Amount { get; set; }
    }
}
