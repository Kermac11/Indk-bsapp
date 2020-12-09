using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Interfaces;
using Indkøbsapp.Models;
using Newtonsoft.Json;

namespace RazorPagesEventMakerIC.Helpers
{
    public class JsonVareWriter
    {
        public static void WriteToJson(List<ButikItems> varer, string filePath)
        {
            string output = JsonConvert.SerializeObject(varer);
            File.WriteAllText(filePath, output);
        }

    }
}
