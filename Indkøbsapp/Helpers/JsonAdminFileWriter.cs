using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Models;
using Newtonsoft.Json;

namespace RazorPagesEventMaker.Helpers
{
    public class JsonAdminFileWriter
    {
        public static void WriteToJson(Dictionary<string,Admin> bruger, string filePath)
        {
            string output = JsonConvert.SerializeObject(bruger);
            File.WriteAllText(filePath, output);
        }

    }
}
