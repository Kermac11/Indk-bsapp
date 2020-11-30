using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Models;
using Newtonsoft.Json;

namespace RazorPagesEventMaker.Helpers
{
    public class JsonFileWriter
    {
        public static void WriteToJson(Dictionary<string,Bruger> bruger, string filePath)
        {
            string output = JsonConvert.SerializeObject(bruger);
            File.WriteAllText(filePath, output);
        }

    }
}
