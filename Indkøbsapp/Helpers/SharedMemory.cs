using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Models;

namespace Indkøbsapp.Helpers
{
    public static class SharedMemory
    {
        public static Bruger LoggedInUser { get; set; }
    }
}
