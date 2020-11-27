using System.Collections.Generic;

namespace Indkøbsapp.Interfaces
{
   public interface IButiksKatalog
   {
        public IButikItems FindItem(int id);
        public void AddItem(IButikItems item);
        public void DeleteItem(int id);
        public Dictionary<int,IButikItems> SortPrices();
        public List<IButikItems> FilterItems(string criteria);
        public Dictionary<int,IButikItems> GetAllButikItems();
    }
}
