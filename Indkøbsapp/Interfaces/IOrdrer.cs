﻿using System.Collections.Generic;
using Indkøbsapp.Models;

namespace Indkøbsapp.Interfaces
{
    public interface IOrdrer
    {
        public List<IButikItems> Order { get; set; }

        public IBruger Buyer { get; set; }
        public int ID { get; set; }
        public decimal Price { get; set; }

        public int AntalVarerIOdrer { get; set; }

    }
}
