using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Models;
using Newtonsoft.Json;

namespace RazorPagesEventMaker.Helpers
{
    public class JsonAdminFileReader
    {
        public static Dictionary<string,Admin> ReadJson(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Dictionary<string,Admin>>(jsonString);
        }

        

    }
}
