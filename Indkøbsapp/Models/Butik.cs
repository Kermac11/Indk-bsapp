using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Indkøbsapp.Models
{
    public class Butik
    {
        [Required]
        public string ButiksNavn { get; set; }
        [Required]
        public string Lokation { get; set; }

        public override bool Equals(Object obj)
        {
            if (obj!= null)
            {
                Butik aButik = (Butik) obj;
                if (aButik.ButiksNavn == ButiksNavn)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
}
