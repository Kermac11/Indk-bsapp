using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Models;
using Newtonsoft.Json;

namespace RazorPagesEventMaker.Helpers
{
    public class JsonCompletedOrderReader
    {
        public static Dictionary<int,CompletedOrder> ReadJson(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Dictionary<int,CompletedOrder>>(jsonString);
        }

        

    }
}
