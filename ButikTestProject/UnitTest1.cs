using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Indkøbsapp;
using Indkøbsapp.Interfaces;
using Indkøbsapp.Models;
using Indkøbsapp.Services;
namespace ButikTestProject
{
    [TestClass]
    public class UnitTest1
    {
        private List<Butik> butikker;
        [TestMethod]
        public void TestMethod1()
        {

            List<Butik> butikker = new List<Butik>();
            butikker.Add(new Butik() { ButiksNavn = "Føtex", Lokation = "Amager" });
        }
    }
}
