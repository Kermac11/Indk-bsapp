using System.Collections.Generic;

namespace Indkøbsapp.Interfaces
{
   public interface IButiksKatalog
    {
        public Dictionary<int, IButikItems> Katalog { get; set; }
        public string ButiksNavn { get; set; }
        public string Lokation { get; set; }

        public IButikItems FindItem(int id);
        public void AddItem(IButikItems item);
        public void DeleteItem(int id);
        public Dictionary<int,IButikItems> SortPrices();
        public Dictionary<int, IButikItems> FilterIems(string criteria);

    }
}
