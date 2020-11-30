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
    public class JsonVareReader
    {
        public static List<ButikItems> ReadJson(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            List<ButikItems> returnList = JsonConvert.DeserializeObject<List<ButikItems>>(jsonString);
            return returnList;
        }

    }
}
