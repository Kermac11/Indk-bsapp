﻿using System.Collections.Generic;
using Indkøbsapp.Models;
using RazorPagesEventMakerIC.Helpers;

namespace Indkøbsapp.Interfaces
{
   public interface IButiksVareKatalog
   {
        public ButikItems FindItem(int id);
        public void AddItem(ButikItems item);
        public void DeleteItem(int id);
        //public Dictionary<int,IButikItems> SortPrices();
        public List<ButikItems> FilterItems(string criteria);
        public Dictionary<int,ButikItems> GetAllButikVarer();

        public void EditVare(ButikItems vare);

   }
}
