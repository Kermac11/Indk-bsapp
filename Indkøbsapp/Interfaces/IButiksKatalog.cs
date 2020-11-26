using System.Collections.Generic;

namespace Indkøbsapp.Interfaces
{
   public interface IButiksKatalog
   {
        public IButikItems FindItem(int id);
        public void AddItem(IButikItems item);
        public void DeleteItem(int id);
        public Dictionary<int,IButikItems> SortPrices();
        public Dictionary<int, IButikItems> FilterItems(string criteria);
        public Dictionary<int,IButikItems> GetAllButikItems();
    }
}
