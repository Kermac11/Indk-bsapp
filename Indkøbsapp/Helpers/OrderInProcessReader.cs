using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Models;
using Newtonsoft.Json;

namespace RazorPagesEventMaker.Helpers
{
    public class OrderInProcessReader
    {
        public static Dictionary<int,Ordrer> ReadJson(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Dictionary<int,Ordrer>>(jsonString);
        }

        

    }
}
