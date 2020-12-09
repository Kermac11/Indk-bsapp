using Indkøbsapp.Helpers;
using Indkøbsapp.Interfaces;
using Indkøbsapp.Models;
using Indkøbsapp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indkøbsapp.Repositories
{
    public class JsonButikRepository : IRepositoryButik
    {
        string JsonFileName = @"Data\JsonButiksStore.json";

        public List<Butik> GetAllButikker()
        {
            return JsonButikFileReader.ReadJsonButik(JsonFileName);
        }
        public void AddButik(Butik butik)
        {
            List<Butik> butikker = GetAllButikker();
            butikker.Add(butik);
            JsonButikFileWritter.WriteToJsonButik(butikker, JsonFileName);
        }

        public Butik GetButik(string butiksNavn)
        {
            foreach (Butik c in GetAllButikker())
            {
                if (c.ButiksNavn == butiksNavn)
                {
                    return c;
                }
            }

            return new Butik();
        }

        public void DeleteButik(string butiksNavn)
        {
            List<Butik> butikker = GetAllButikker();
            Butik foundButik = GetButik(butiksNavn);
            if (foundButik != null)
            {
                butikker.Remove(foundButik);
            }
            JsonButikFileWritter.WriteToJsonButik(butikker, JsonFileName);
        }

    }
}
