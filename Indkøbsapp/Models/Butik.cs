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
    }
}
