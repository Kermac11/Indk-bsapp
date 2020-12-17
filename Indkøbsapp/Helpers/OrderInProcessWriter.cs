using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Models;
using Newtonsoft.Json;

namespace RazorPagesEventMaker.Helpers
{
    public class OrderInProcessWriter
    {
        public static void WriteToJson(Dictionary<int,Ordrer> ordrer, string filePath)
        {
            string output = JsonConvert.SerializeObject(ordrer);
            File.WriteAllText(filePath, output);
        }

    }
}
