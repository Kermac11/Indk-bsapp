using Indkøbsapp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Indkøbsapp.Helpers
{
    public class JsonButikFileReader
    {
        public static List<Butik> ReadJsonButik(string JsonFileName)
        {
            string jsonString = File.ReadAllText(JsonFileName);

            return JsonSerializer.Deserialize<List<Butik>>(jsonString);
        }
    }
}
