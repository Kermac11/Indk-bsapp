﻿namespace Indkøbsapp.Interfaces
{
    interface IButikItems
    { 
        public int ID { get; set; }
        public string Navn { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
