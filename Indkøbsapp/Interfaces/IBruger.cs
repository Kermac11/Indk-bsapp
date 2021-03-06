﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indkøbsapp.Models
{
    public interface IBruger
    {
        public string Navn { get; set; }
        public int ID { get; set; }
        public string By { get; set; }
        public string Adresse { get; set; }
        public DateTime CreationDate { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public bool Leverandør { get; set; } 
    }
}
