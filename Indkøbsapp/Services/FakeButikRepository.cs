using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Interfaces;
using Indkøbsapp.Models;

namespace Indkøbsapp.Services
{
    public class FakeButikRepository
    {
        private List<Butik> butikker { get; }

        public FakeButikRepository()
        {
            butikker = new List<Butik>();
            butikker.Add(new Butik() { ButiksNavn = "Føtex", Lokation = "Amager" });
            butikker.Add(new Butik() { ButiksNavn = "Netto", Lokation = "Frederiksberg" });
        }

        public List<Butik> GetAllButikker()
        {
            return butikker;
        }

        public int Count
        {
            get { return butikker.Count; }
        }
        public string GetButiksNavn(string butiksNavn)
        {
            foreach (Butik b in butikker)
            {
                if (b.ButiksNavn == butiksNavn)
                {
                    return b.ButiksNavn;
                }
            }

            return null;
        }

        public Butik GetButik(string butiksNavn)
        {
            foreach (Butik c in butikker)
            {
                if (c.ButiksNavn == butiksNavn)
                {
                    return c;
                }
            }

            return null;
        }
        public void AddButik(Butik butik)
        {
            butikker.Add(butik);
        }

        public Butik LookUpButik(string butiksNavn)
        {
            foreach(Butik b in butikker)
            {
                if (b.ButiksNavn == butiksNavn)
                    return b;
            }
            return null;
        }

        public void DeleteButik(string butiksNavn)
        {
            Butik foundButik = LookUpButik(butiksNavn);
            if(foundButik != null)
            {
                butikker.Remove(foundButik);
            }
        }
    }
}


