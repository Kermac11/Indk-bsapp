﻿using System.Collections.Generic;
using Indkøbsapp.Models;

namespace Indkøbsapp.Interfaces
{
    public interface IOrdrer
    {
        public List<OrderItem> Order { get; set; }

        public Bruger Buyer { get; set; }
        public int ID { get; set; }
        public double Price { get; set; }

        public void AddItem(ButikItems item);
        public void DeleteItem(int id);
    }
}
