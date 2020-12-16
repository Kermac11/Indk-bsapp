using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Models;
using Newtonsoft.Json;

namespace RazorPagesEventMaker.Helpers
{
    public class JsonCompletedOrderWriter
    {
        public static void WriteToJson(Dictionary<int,CompletedOrder> ordrer, string filePath)
        {
            string output = JsonConvert.SerializeObject(ordrer);
            File.WriteAllText(filePath, output);
        }

    }
}
