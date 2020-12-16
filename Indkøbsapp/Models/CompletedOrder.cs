using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indkøbsapp.Models
{
    public class CompletedOrder
    {

        // Denne klasse er den samme som ordrer men har en leverandør tilsat
        public CompletedOrder(Ordrer ordrer )
        {
            Ordrer = ordrer;
        }

        public Ordrer Ordrer { get; set; }

        //Bruges til at se hvem der har leveret ordren
        public Bruger Leverandør { get; set; }
    }
}
