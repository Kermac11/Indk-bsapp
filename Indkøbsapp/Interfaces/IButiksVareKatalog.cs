using System.Collections.Generic;
using Indkøbsapp.Models;
using RazorPagesEventMakerIC.Helpers;

namespace Indkøbsapp.Interfaces
{
   public interface IButiksVareKatalog
   {
        public IButikItems FindItem(int id);
        public void AddItem(ButikItems item);
        public void DeleteItem(int id);
        //public Dictionary<int,IButikItems> SortPrices();
        public List<IButikItems> FilterItems(string criteria);
        public Dictionary<int,ButikItems> GetAllButikVarer();

        public void EditVare(IButikItems vare);

   }
}
