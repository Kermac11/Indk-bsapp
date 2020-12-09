using Indkøbsapp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Indkøbsapp.Helpers
{
    public class JsonButikFileWritter
    {

        public static void WriteToJsonButik(List<Butik> butikker, string JsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(butikker);
            File.WriteAllText(JsonFileName, output); 
        }
    }
}
