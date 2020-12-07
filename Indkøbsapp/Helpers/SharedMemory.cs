using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Indkøbsapp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;

namespace Indkøbsapp.Helpers
{
    public static class SharedMemory
    {
        public static Bruger LoggedInUser { get; set; }

        public static Ordrer ActiveOrdrer { get; set; }
    }
}
