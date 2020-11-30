using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Indkøbsapp.Models
{
    public class Bruger: IBruger
    {
        [Required]
        public string Navn { get; set; }
        public int ID { get; set; }
        [Required]
        public string Adresse { get; set; }
        public DateTime CreationDate { get; set; }
        [Required]
        public string PassWord { get; set; }
        public bool Leverandør { get; set; }
    }
}
