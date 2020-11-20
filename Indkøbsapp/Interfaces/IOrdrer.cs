using System.Collections.Generic;

namespace Indkøbsapp.Interfaces
{
    interface IOrdrer
    {
        public List<IButikItems> Order { get; set; }

        public decimal Price { get; set; }

        public int AntalVarerIOdrer { get; set; }

    }
}
